using DevMeet.Services;
using DevMeetData.DTO;
using DevMeetData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMeetTests.Services
{
    public class SeatServiceFake : ISeatService
    {
        private readonly List<SeatDTO> _seats;

        public SeatServiceFake()
        {
            _seats = new List<SeatDTO>()
            {
                new SeatDTO() { Id = 1, Column = 1, Row="A" },
                new SeatDTO() { Id = 2, Column = 2, Row="A" },
                new SeatDTO() { Id = 3, Column = 3, Row="A" },

                new SeatDTO() { Id = 4, Column = 1, Row="B" },
                new SeatDTO() { Id = 5, Column = 2, Row="B" },
                new SeatDTO() { Id = 6, Column = 3, Row="B" },

                new SeatDTO() { Id = 7, Column = 1, Row="C" },
                new SeatDTO() { Id = 8, Column = 2, Row="C" },
                new SeatDTO() { Id = 9, Column = 3, Row="C" }
            };
        }

        public async Task<IEnumerable<SeatDTO>> GetSeats()
        {
            return _seats;
        }

        public async Task<SeatDTO> Get(int id)
        {
            var seat = _seats.Where(x => x.Id == id)
            .FirstOrDefault();

            return seat;
        }

        public async Task<SeatDTO> Add(Seat seat)
        {
            seat.Id = 10;

            var seatDTO = new SeatDTO()
            {
                Id = seat.Id,
                Column = seat.Column,
                Row = seat.Row
            };
            
            _seats.Add(seatDTO);
            return seatDTO;
        }

        public async Task<SeatDTO> Delete(int id)
        {
            if (SeatExists(id))
            {
                var existingSeat = _seats.First(a => a.Id == id);
                _seats.Remove(existingSeat);
                return existingSeat;
            }
            return null;
        }
        public bool SeatExists(int id)
        {
            return _seats.Any(e => e.Id == id);
        }

        public async Task<SeatDTO> Update(Seat seat)
        {
            throw new NotImplementedException();
        }
    }
}
