using System;
using System.Collections.Generic;
using System.Text;

namespace DevMeetData.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public DateTime EventDateTime { get; set; }
        public List<SeatDTO> AvailableSeats { get; set; }
        public List<SeatDTO> BookedSeats { get; set; }
    }
}
