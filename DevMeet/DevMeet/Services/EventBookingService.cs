using DevMeetData.DTO;
using DevMeetData.Models;
using DevMeetData.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevMeet.Services
{
    public class EventBookingService : IEventBookingService
    {
        private readonly EventBookingRepository _eventBookingRepository;

        public EventBookingService(EventBookingRepository eventBookingRepository)
        {
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<IEnumerable<EventBookingDTO>> GetEventBookings()
        {
            var eventBookings = await _eventBookingRepository.GetAll();

            var eventBookingList = from eventBooking in eventBookings
                           select new EventBookingDTO()
                           {
                                Id = eventBooking.Id,
                                EventId = eventBooking.EventId,
                                BookingItemOneId = eventBooking.BookingItemOneId,
                                BookingItemSecondId = eventBooking.BookingItemSecondId,
                                BookingItemThreeId = eventBooking.BookingItemThreeId,
                                BookingItemFourId = eventBooking.BookingItemFourId
                           };

            return eventBookingList;
        }

        public async Task<EventBookingDTO> Get(int id)
        {
            var eventBooking = await _eventBookingRepository.Get(id);

            var eventBookingDTO = new EventBookingDTO()
            {
                Id = eventBooking.Id,
                EventId = eventBooking.EventId,
                BookingItemOneId = eventBooking.BookingItemOneId,
                BookingItemSecondId = eventBooking.BookingItemSecondId,
                BookingItemThreeId = eventBooking.BookingItemThreeId,
                BookingItemFourId = eventBooking.BookingItemFourId
            };

            return eventBookingDTO;
        }

        public async Task<EventBookingDTO> Update(EventBooking eventBooking)
        {
            var updatedEventBooking = await _eventBookingRepository.Update(eventBooking);

            var eventBookingDTO = new EventBookingDTO()
            {
                Id = updatedEventBooking.Id,
                EventId = updatedEventBooking.EventId,
                BookingItemOneId = updatedEventBooking.BookingItemOneId,
                BookingItemSecondId = updatedEventBooking.BookingItemSecondId,
                BookingItemThreeId = updatedEventBooking.BookingItemThreeId,
                BookingItemFourId = updatedEventBooking.BookingItemFourId
            };

            return eventBookingDTO;
        }

        public async Task<EventBookingDTO> Add(EventBooking eventBooking)
        {
            await _eventBookingRepository.Add(eventBooking);

            var eventBookingDTO = new EventBookingDTO()
            {
                Id = eventBooking.Id,
                EventId = eventBooking.EventId,
                BookingItemOneId = eventBooking.BookingItemOneId,
                BookingItemSecondId = eventBooking.BookingItemSecondId,
                BookingItemThreeId = eventBooking.BookingItemThreeId,
                BookingItemFourId = eventBooking.BookingItemFourId
            };

            return eventBookingDTO;
        }

        public async Task<EventBookingDTO> Delete(int id)
        {
            var eventBooking = await _eventBookingRepository.Delete(id);

            if (eventBooking == null)
            {
                return null;
            }

            var eventBookingDTO = new EventBookingDTO()
            {
                Id = eventBooking.Id,
                EventId = eventBooking.EventId,
                BookingItemOneId = eventBooking.BookingItemOneId,
                BookingItemSecondId = eventBooking.BookingItemSecondId,
                BookingItemThreeId = eventBooking.BookingItemThreeId,
                BookingItemFourId = eventBooking.BookingItemFourId
            };

            return eventBookingDTO;
        }

        public bool EventBookingExists(int id)
        {
            return _eventBookingRepository.ItemExists(id);
        }

    }
}
