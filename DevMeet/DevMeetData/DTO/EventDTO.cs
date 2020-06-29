using System;
using System.Collections.Generic;

namespace DevMeetData.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDateTime { get; set; }
        public List<SeatDTO> AvailableSeats { get; set; }
        public List<SeatDTO> BookedSeats { get; set; }
    }
}
