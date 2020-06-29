using DevMeet.Services;
using DevMeetData.DTO;
using DevMeetData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevMeet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        // GET: api/Seats
        [HttpGet]
        public async Task<IEnumerable<SeatDTO>> GetSeats()
        {
            return await _seatService.GetSeats();
        }

        // GET: api/Seats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatDTO>> GetSeat(int id)
        {
            var seat = await _seatService.Get(id);

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

            SeatDTO updatedSeat = new SeatDTO();

            try
            {
                updatedSeat = await _seatService.Update(seat);
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
        public async Task<SeatDTO> PostSeat(Seat seat)
        {
            return await _seatService.Add(seat);
        }

        // DELETE: api/Seats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SeatDTO>> DeleteSeat(int id)
        {
            var seat = await _seatService.Delete(id);
            if (seat == null)
            {
                return NotFound();
            }
            return seat;
        }

        private bool SeatExists(int id)
        {
            return _seatService.SeatExists(id);
        }
    }
}
