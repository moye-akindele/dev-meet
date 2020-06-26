using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevMeetData.Models;
using DevMeetData.Repositories;

namespace DevMeet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeatsController : ControllerBase
    {
        private readonly SeatRepository _seatRepository;

        public SeatsController(SeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        // GET: api/Seats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeats()
        {
            return await _seatRepository.GetAll();
        }

        // GET: api/Seats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetSeat(int id)
        {
            var seat = await _seatRepository.Get(id);

            if (seat == null)
            {
                return NotFound();
            }

            return seat;
        }

        // PUT: api/Seats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeat(int id, Seat seat)
        {
            if (id != seat.Id)
            {
                return BadRequest();
            }

            Seat updatedSeat = new Seat();

            try
            {
                updatedSeat = await _seatRepository.Update(seat);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return (IActionResult)updatedSeat;
        }

        // POST: api/Seats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Seat>> PostSeat(Seat seat)
        {
            return await _seatRepository.Add(seat);
        }

        // DELETE: api/Seats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seat>> DeleteSeat(int id)
        {
            var seat = await _seatRepository.Delete(id);
            if (seat == null)
            {
                return NotFound();
            }
            return seat;
        }

        private bool SeatExists(int id)
        {
            return _seatRepository.ItemExists(id);
        }
    }
}
