namespace DevMeetData.Models
{
    public class BookingItem : IEntity
    {
        public int Id { get; set; }
        public int EventBookingId { get; set; }
        public int SeatId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
