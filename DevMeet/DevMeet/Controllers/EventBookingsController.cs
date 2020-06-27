using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevMeetData.Context;
using DevMeetData.Models;
using DevMeetData.Repositories;

namespace DevMeet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventBookingsController : ControllerBase
    {
        private readonly EventBookingRepository _eventBookingRepository;

        public EventBookingsController(EventBookingRepository eventBookingRepository)
        {
            _eventBookingRepository = eventBookingRepository;
        }

        // GET: api/EventBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventBooking>>> GetEventBookings()
        {
            return await _eventBookingRepository.GetAll();
        }

        // GET: api/EventBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventBooking>> GetEventBooking(int id)
        {
            var eventBooking = await _eventBookingRepository.Get(id);

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

            EventBooking updatedEventBooking = new EventBooking();

            try
            {
                updatedEventBooking = await _eventBookingRepository.Update(eventBooking);
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
        public async Task<ActionResult<EventBooking>> PostEventBooking(EventBooking eventBooking)
        {
            return await _eventBookingRepository.Add(eventBooking);
        }

        // DELETE: api/EventBookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventBooking>> DeleteEventBooking(int id)
        {
            var eventBooking = await _eventBookingRepository.Delete(id);
            if (eventBooking == null)
            {
                return NotFound();
            }
            return eventBooking;
        }

        private bool EventBookingExists(int id)
        {
            return _eventBookingRepository.ItemExists(id);
        }
    }
}
