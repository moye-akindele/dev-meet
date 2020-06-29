using DevMeetData.DTO;
using DevMeetData.Models;
using DevMeetData.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevMeet.Services
{
    public class EventService : IEventService
    {
        private readonly EventRepository _eventRepository;
        public EventService(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<IEnumerable<EventDTO>> GetEvents()
        {
            var events = await _eventRepository.GetAll();

            var eventList = from devEvent in events
                           select new EventDTO()
                           {
                                Id = devEvent.Id,
                                EventName = devEvent.EventName,
                                EventDateTime = devEvent.EventDateTime,
                                AvailableSeats = (List<SeatDTO>)(from seat in devEvent.AvailableSeats
                                                 select new SeatDTO()
                                                 {
                                                     Id = seat.Id,
                                                     Column = seat.Column,
                                                     Row = seat.Row
                                                 }),
                                BookedSeats = (List<SeatDTO>)(from seat in devEvent.BookedSeats
                                              select new SeatDTO()
                                              {
                                                  Id = seat.Id,
                                                  Column = seat.Column,
                                                  Row = seat.Row
                                              })
                           };

            return eventList;
        }

        public async Task<EventDTO> Get(int id)
        {
            var devEvent = await _eventRepository.Get(id);

            var eventDTO = new EventDTO()
            {
                Id = devEvent.Id,
                EventName = devEvent.EventName,
                EventDateTime = devEvent.EventDateTime,
                AvailableSeats = (List<SeatDTO>)(from seat in devEvent.AvailableSeats
                                                 select new SeatDTO()
                                                 {
                                                     Id = seat.Id,
                                                     Column = seat.Column,
                                                     Row = seat.Row
                                                 }),
                BookedSeats = (List<SeatDTO>)(from seat in devEvent.BookedSeats
                                              select new SeatDTO()
                                              {
                                                  Id = seat.Id,
                                                  Column = seat.Column,
                                                  Row = seat.Row
                                              })
            };

            return eventDTO;
        }

        public async Task<EventDTO> Update(Event devEvent)
        {
            var updatedEvent = await _eventRepository.Update(devEvent);

            var eventDTO = new EventDTO()
            {
                Id = updatedEvent.Id,
                EventName = updatedEvent.EventName,
                EventDateTime = updatedEvent.EventDateTime,
                AvailableSeats = (List<SeatDTO>)(from seat in updatedEvent.AvailableSeats
                                                 select new SeatDTO()
                                                 {
                                                     Id = seat.Id,
                                                     Column = seat.Column,
                                                     Row = seat.Row
                                                 }),
                BookedSeats = (List<SeatDTO>)(from seat in updatedEvent.BookedSeats
                                              select new SeatDTO()
                                              {
                                                  Id = seat.Id,
                                                  Column = seat.Column,
                                                  Row = seat.Row
                                              })
            };

            return eventDTO;
        }

        public async Task<EventDTO> Add(Event devEvent)
        {
            await _eventRepository.Add(devEvent);

            var eventDTO = new EventDTO()
            {
                Id = devEvent.Id,
                EventName = devEvent.EventName,
                EventDateTime = devEvent.EventDateTime,
                AvailableSeats = (List<SeatDTO>)(from seat in devEvent.AvailableSeats
                                                 select new SeatDTO()
                                                 {
                                                     Id = seat.Id,
                                                     Column = seat.Column,
                                                     Row = seat.Row
                                                 }),
                BookedSeats = (List<SeatDTO>)(from seat in devEvent.BookedSeats
                                              select new SeatDTO()
                                              {
                                                  Id = seat.Id,
                                                  Column = seat.Column,
                                                  Row = seat.Row
                                              })
            };

            return eventDTO;
        }

        public async Task<EventDTO> Delete(int id)
        {
            var devEvent = await _eventRepository.Delete(id);

            if (devEvent == null)
            {
                return null;
            }

            var eventDTO = new EventDTO()
            {
                Id = devEvent.Id,
                EventName = devEvent.EventName,
                EventDateTime = devEvent.EventDateTime,
                AvailableSeats = (List<SeatDTO>)(from seat in devEvent.AvailableSeats
                                                 select new SeatDTO()
                                                 {
                                                     Id = seat.Id,
                                                     Column = seat.Column,
                                                     Row = seat.Row
                                                 }),
                BookedSeats = (List<SeatDTO>)(from seat in devEvent.BookedSeats
                                              select new SeatDTO()
                                              {
                                                  Id = seat.Id,
                                                  Column = seat.Column,
                                                  Row = seat.Row
                                              })
            };

            return eventDTO;
        }

        public bool EventExists(int id)
        {
            return _eventRepository.ItemExists(id);
        }
    }
}
