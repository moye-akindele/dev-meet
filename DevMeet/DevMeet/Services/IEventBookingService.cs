using DevMeetData.DTO;
using DevMeetData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevMeet.Services
{
    public interface IEventBookingService
    {
        Task<IEnumerable<EventBookingDTO>> GetEventBookings();
        Task<EventBookingDTO> Get(int id);
        Task<EventBookingDTO> Update(EventBooking eventBooking);
        Task<EventBookingDTO> Add(EventBooking eventBooking);
        Task<EventBookingDTO> Delete(int id);
        bool EventBookingExists(int id);
    }
}
