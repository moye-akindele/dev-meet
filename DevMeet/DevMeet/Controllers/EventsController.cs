using DevMeetData.Models;
using DevMeetData.Repositories;
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
        private readonly EventRepository _eventsRepository;

        public EventsController(EventRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _eventsRepository.GetAll();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var devEvent = await _eventsRepository.Get(id);

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

            Event updatedEvent = new Event();

            try
            {
                updatedEvent = await _eventsRepository.Update(devEvent);
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
        public async Task<ActionResult<Event>> PostEvent(Event devEvent)
        {
            return await _eventsRepository.Add(devEvent);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            var devEvent = await _eventsRepository.Delete(id);
            if (devEvent == null)
            {
                return NotFound();
            }
            return devEvent;
        }

        private bool EventExists(int id)
        {
            return _eventsRepository.ItemExists(id);
        }
    }
}
