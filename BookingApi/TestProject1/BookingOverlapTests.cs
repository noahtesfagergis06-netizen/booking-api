using Microsoft.EntityFrameworkCore;
using BookingApi.Data;
using BookingApi.Models;
using Xunit;

namespace BookingApi.Tests
{
    public class BookingOverlapTests
    {
        private AppDbContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task OverlappingBooking_ForSameStylist_ShouldBeDetected()
        {
            // Arrange
            using var context = GetInMemoryContext();

            var stylist = new Stylist { Name = "Anna", Email = "anna@test.com", WorksSince = DateTime.UtcNow };
            context.Stylists.Add(stylist);
            await context.SaveChangesAsync();

            var existingBooking = new Booking
            {
                StylistId = stylist.Id,
                CustomerId = 1,
                ServiceId = 1,
                StartTime = new DateTime(2026, 9, 10, 10, 0, 0),
                EndTime = new DateTime(2026, 9, 10, 11, 0, 0),
                Status = BookingStatus.Confirmed
            };
            context.Bookings.Add(existingBooking);
            await context.SaveChangesAsync();

            var newStart = new DateTime(2026, 9, 10, 10, 30, 0);
            var newEnd = new DateTime(2026, 9, 10, 11, 30, 0);

            // Act
            bool overlaps = await context.Bookings.AnyAsync(b =>
                b.StylistId == stylist.Id &&
                b.Status != BookingStatus.Cancelled &&
                newStart < b.EndTime &&
                newEnd > b.StartTime);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public async Task NonOverlappingBooking_ForSameStylist_ShouldNotBeDetected()
        {
            // Arrange
            using var context = GetInMemoryContext();

            var stylist = new Stylist { Name = "Anna", Email = "anna@test.com", WorksSince = DateTime.UtcNow };
            context.Stylists.Add(stylist);
            await context.SaveChangesAsync();

            var existingBooking = new Booking
            {
                StylistId = stylist.Id,
                CustomerId = 1,
                ServiceId = 1,
                StartTime = new DateTime(2026, 9, 10, 10, 0, 0),
                EndTime = new DateTime(2026, 9, 10, 11, 0, 0),
                Status = BookingStatus.Confirmed
            };
            context.Bookings.Add(existingBooking);
            await context.SaveChangesAsync();

            var newStart = new DateTime(2026, 9, 10, 12, 0, 0);
            var newEnd = new DateTime(2026, 9, 10, 13, 0, 0);

            // Act
            bool overlaps = await context.Bookings.AnyAsync(b =>
                b.StylistId == stylist.Id &&
                b.Status != BookingStatus.Cancelled &&
                newStart < b.EndTime &&
                newEnd > b.StartTime);

            // Assert
            Assert.False(overlaps);
        }
    }
}