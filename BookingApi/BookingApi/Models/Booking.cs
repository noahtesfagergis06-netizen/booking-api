namespace BookingApi.Models
{
    public enum BookingStatus
    {
        Confirmed,
        Cancelled,
        Completed
    }
    public class Booking
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int StylistId { get; set; }
        public Stylist Stylist { get; set; } = null!;

        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Confirmed;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }
    }
}
