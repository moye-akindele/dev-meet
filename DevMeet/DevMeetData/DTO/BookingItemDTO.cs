namespace DevMeetData.DTO
{
    public class BookingItemDTO
    {
        public long Id { get; set; }
        public int EventBookingId { get; set; }
        public int SeatId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
