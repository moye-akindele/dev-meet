using DevMeetData.DTO;
using DevMeetData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevMeet.Services
{
    public interface ISeatService
    {
        Task<IEnumerable<SeatDTO>> GetSeats();
        Task<SeatDTO> Get(int id);
        Task<SeatDTO> Update(Seat seat);
        Task<SeatDTO> Add(Seat seat);
        Task<SeatDTO> Delete(int id);
        bool SeatExists(int id);
    }
}
