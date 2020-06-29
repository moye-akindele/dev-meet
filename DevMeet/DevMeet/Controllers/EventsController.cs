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
    public class EventsController : ControllerBase
    {
        // private readonly EventRepository _eventsRepository;
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<IEnumerable<EventDTO>> GetEvents()
        {
            return await _eventService.GetEvents();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDTO>> GetEvent(int id)
        {
            var devEvent = await _eventService.Get(id);

            if (devEvent == null)
            {
                return NotFound();
            }

            return devEvent;
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event devEvent)
        {
            if (id != devEvent.Id)
            {
                return BadRequest();
            }

            EventDTO updatedEvent = new EventDTO();

            try
            {
                updatedEvent = await _eventService.Update(devEvent);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return (IActionResult)updatedEvent;
        }

        // POST: api/Events
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<EventDTO> PostEvent(Event devEvent)
        {
            return await _eventService.Add(devEvent);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventDTO>> DeleteEvent(int id)
        {
            var devEvent = await _eventService.Delete(id);
            if (devEvent == null)
            {
                return NotFound();
            }
            return devEvent;
        }

        private bool EventExists(int id)
        {
            return _eventService.EventExists(id);
        }
    }
}
