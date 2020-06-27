using DevMeetData.Context;
using DevMeetData.Models;

namespace DevMeetData.Repositories
{
    public class EventBookingRepository : BaseRepository<EventBooking, ApplicationContext>
    {
        public EventBookingRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
