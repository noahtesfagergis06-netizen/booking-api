namespace BookingApi.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public decimal Price { get; set; }

        // Navigation property: one service can appear in many bookings
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
