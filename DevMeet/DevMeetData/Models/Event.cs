using System;
using System.Collections.Generic;

namespace DevMeetData.Models
{
    public class Event : IEntity
    {
        public int Id { get; set; }
        public DateTime EventDateTime { get; set; }
        public List<Seat> AvailableSeats { get; set; }
        public List<Seat> BookedSeats { get; set; }
    }
}
