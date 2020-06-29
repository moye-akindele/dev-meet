using DevMeetData.DTO;
using DevMeetData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevMeet.Services
{
    public interface IBookingItemService
    {
        Task<IEnumerable<BookingItemDTO>> GetBookingItems();
        Task<BookingItemDTO> Get(int id);
        Task<BookingItemDTO> Update(BookingItem bookingItem);
        Task<BookingItemDTO> Add(BookingItem bookingItem);
        Task<BookingItemDTO> Delete(int id);
        bool BookingItemExists(int id);
    }
}
