namespace BookingApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property: one customer can have many bookings
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
