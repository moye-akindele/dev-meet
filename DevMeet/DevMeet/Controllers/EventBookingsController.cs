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
    public class EventBookingsController : ControllerBase
    {
        private readonly IEventBookingService _eventBookingService;

        public EventBookingsController(IEventBookingService eventBookingService)
        {
            _eventBookingService = eventBookingService;
        }

        // GET: api/EventBookings
        [HttpGet]
        public async Task<IEnumerable<EventBookingDTO>> GetEventBookings()
        {
            return await _eventBookingService.GetEventBookings();
        }

        // GET: api/EventBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventBookingDTO>> GetEventBooking(int id)
        {
            var eventBooking = await _eventBookingService.Get(id);

            if (eventBooking == null)
            {
                return NotFound();
            }

            return eventBooking;
        }

        // PUT: api/EventBookings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventBooking(int id, EventBooking eventBooking)
        {
            if (id != eventBooking.Id)
            {
                return BadRequest();
            }

            EventBookingDTO updatedEventBooking = new EventBookingDTO();

            try
            {
                updatedEventBooking = await _eventBookingService.Update(eventBooking);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventBookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return (IActionResult)updatedEventBooking;
        }

        // POST: api/EventBookings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventBookingDTO>> PostEventBooking(EventBooking eventBooking)
        {
            return await _eventBookingService.Add(eventBooking);
        }

        // DELETE: api/EventBookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventBookingDTO>> DeleteEventBooking(int id)
        {
            var eventBooking = await _eventBookingService.Delete(id);
            if (eventBooking == null)
            {
                return NotFound();
            }
            return eventBooking;
        }

        private bool EventBookingExists(int id)
        {
            return _eventBookingService.EventBookingExists(id);
        }
    }
}
