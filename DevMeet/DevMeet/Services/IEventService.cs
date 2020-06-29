using DevMeetData.DTO;
using DevMeetData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevMeet.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventDTO>> GetEvents();
        Task<EventDTO> Get(int id);
        Task<EventDTO> Update(Event devEvent);
        Task<EventDTO> Add(Event devEvent);
        Task<EventDTO> Delete(int id);
        bool EventExists(int id);
    }
}
