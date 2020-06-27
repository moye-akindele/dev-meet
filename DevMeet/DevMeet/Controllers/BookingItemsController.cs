using DevMeetData.Models;
using DevMeetData.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevMeet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingItemsController : ControllerBase
    {
        private readonly BookingItemRepository _bookingItemRepository;

        public BookingItemsController(BookingItemRepository bookingItemRepository)
        {
            _bookingItemRepository = bookingItemRepository;
        }

        // GET: api/BookingItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingItem>>> GetBookingItems()
        {
            return await _bookingItemRepository.GetAll();
        }

        // GET: api/BookingItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingItem>> GetBookingItem(int id)
        {
            var bookingItem = await _bookingItemRepository.Get(id);

            if (bookingItem == null)
            {
                return NotFound();
            }

            return bookingItem;
        }

        // PUT: api/BookingItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingItem(int id, BookingItem bookingItem)
        {
            if (id != bookingItem.Id)
            {
                return BadRequest();
            }

            BookingItem updatedBookingItem = new BookingItem();

            try
            {
                updatedBookingItem = await _bookingItemRepository.Update(bookingItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return (IActionResult)updatedBookingItem;
        }

        // POST: api/BookingItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookingItem>> PostBookingItem(BookingItem bookingItem)
        {
            return await _bookingItemRepository.Add(bookingItem);
        }

        // DELETE: api/BookingItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingItem>> DeleteBookingItem(int id)
        {
            var bookingItem = await _bookingItemRepository.Delete(id);
            if (bookingItem == null)
            {
                return NotFound();
            }
            return bookingItem;
        }

        private bool BookingItemExists(int id)
        {
            return _bookingItemRepository.ItemExists(id);
        }
    }
}
