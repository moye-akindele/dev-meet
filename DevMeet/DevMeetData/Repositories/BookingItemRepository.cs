using DevMeetData.Context;
using DevMeetData.Models;

namespace DevMeetData.Repositories
{
    public class BookingItemRepository : BaseRepository<BookingItem, ApplicationContext>
    {
        public BookingItemRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
