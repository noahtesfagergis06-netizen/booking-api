namespace BookingApi.Models
{
    public class Stylist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime WorksSince { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation property: one stylist can have many bookings
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
