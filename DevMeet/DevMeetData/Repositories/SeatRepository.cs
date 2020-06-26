using DevMeetData.Context;
using DevMeetData.Models;

namespace DevMeetData.Repositories
{
    public class SeatRepository : BaseRepository<Seat, ApplicationContext>
    {
        public SeatRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}
