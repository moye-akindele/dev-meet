using DevMeetData.DTO;
using DevMeetData.Models;
using DevMeetData.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevMeet.Services
{
    public class SeatService : ISeatService
    {
        private readonly SeatRepository _seatRepository;

        public SeatService(SeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<IEnumerable<SeatDTO>> GetSeats()
        {
            var seats = await _seatRepository.GetAll();

            var seatList = from seat in seats
                           select new SeatDTO()
                           {
                               Id = seat.Id,
                               Column = seat.Column,
                               Row = seat.Row
                           };

            return seatList;
        }

        public async Task<SeatDTO> Get(int id)
        {
            var seat = await _seatRepository.Get(id);

            var seatDTO = new SeatDTO()
            {
                Id = seat.Id,
                Column = seat.Column,
                Row = seat.Row
            };

            return seatDTO;
        }

        public async Task<SeatDTO> Update(Seat seat)
        {
            var updatedSeat = await _seatRepository.Update(seat);

            var seatDTO = new SeatDTO()
            {
                Id = updatedSeat.Id,
                Column = updatedSeat.Column,
                Row = updatedSeat.Row
            };

            return seatDTO;
        }

        public async Task<SeatDTO> Add(Seat seat)
        {
            await _seatRepository.Add(seat);

            var seatDTO = new SeatDTO()
            {
                Id = seat.Id,
                Column = seat.Column,
                Row = seat.Row
            };

            return seatDTO;
        }

        public async Task<SeatDTO> Delete(int id)
        {
            var seat = await _seatRepository.Delete(id);

            if (seat == null)
            {
                return null;
            }

            var seatDTO = new SeatDTO()
            {
                Id = seat.Id,
                Column = seat.Column,
                Row = seat.Row
            };

            return seatDTO;
        }

        public bool SeatExists(int id)
        {
            return _seatRepository.ItemExists(id);
        }
    }
}
