namespace DevMeetData.DTO
{
    public class EventBookingDTO
    {
        public long Id { get; set; }
        public int EventId { get; set; }
        public int BookingItemOneId { get; set; }
        public int BookingItemSecondId { get; set; }
        public int BookingItemThreeId { get; set; }
        public int BookingItemFourId { get; set; }
    }
}
