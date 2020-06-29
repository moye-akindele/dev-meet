using DevMeetData.DTO;
using DevMeetData.Models;
using DevMeetData.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevMeet.Services
{
    public class BookingItemService : IBookingItemService
    {
        private readonly BookingItemRepository _bookingItemRepository;
        public BookingItemService(BookingItemRepository bookingItemRepository)
        {
            _bookingItemRepository = bookingItemRepository;
        }

        public async Task<IEnumerable<BookingItemDTO>> GetBookingItems()
        {
            var bookingItems = await _bookingItemRepository.GetAll();

            var bookingItemList = from bookingItem in bookingItems
                           select new BookingItemDTO()
                           {
                                Id = bookingItem.Id,
                                EventBookingId = bookingItem.EventBookingId,
                                SeatId = bookingItem.SeatId,
                                Name = bookingItem.Name,
                                Email = bookingItem.Email
                           };

            return bookingItemList;
        }

        public async Task<BookingItemDTO> Get(int id)
        {
            var bookingItem = await _bookingItemRepository.Get(id);

            var bookingItemDTO = new BookingItemDTO()
            {
                Id = bookingItem.Id,
                EventBookingId = bookingItem.EventBookingId,
                SeatId = bookingItem.SeatId,
                Name = bookingItem.Name,
                Email = bookingItem.Email
            };

            return bookingItemDTO;
        }

        public async Task<BookingItemDTO> Update(BookingItem bookingItem)
        {
            var updatedBookingItem = await _bookingItemRepository.Update(bookingItem);

            var bookingItemDTO = new BookingItemDTO()
            {
                Id = updatedBookingItem.Id,
                EventBookingId = updatedBookingItem.EventBookingId,
                SeatId = updatedBookingItem.SeatId,
                Name = updatedBookingItem.Name,
                Email = updatedBookingItem.Email
            };

            return bookingItemDTO;
        }

        public async Task<BookingItemDTO> Add(BookingItem bookingItem)
        {
            await _bookingItemRepository.Add(bookingItem);

            var bookingItemDTO = new BookingItemDTO()
            {
                Id = bookingItem.Id,
                EventBookingId = bookingItem.EventBookingId,
                SeatId = bookingItem.SeatId,
                Name = bookingItem.Name,
                Email = bookingItem.Email
            };

            return bookingItemDTO;
        }

        public async Task<BookingItemDTO> Delete(int id)
        {
            var bookingItem = await _bookingItemRepository.Delete(id);

            if (bookingItem == null)
            {
                return null;
            }

            var bookingItemDTO = new BookingItemDTO()
            {
                Id = bookingItem.Id,
                EventBookingId = bookingItem.EventBookingId,
                SeatId = bookingItem.SeatId,
                Name = bookingItem.Name,
                Email = bookingItem.Email
            };

            return bookingItemDTO;
        }

        public bool BookingItemExists(int id)
        {
            return _bookingItemRepository.ItemExists(id);
        }
    }
}
