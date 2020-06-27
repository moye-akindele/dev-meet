using DevMeetData.Context;
using DevMeetData.Models;

namespace DevMeetData.Repositories
{
    public class EventRepository : BaseRepository<Event, ApplicationContext>
    {
        public EventRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
