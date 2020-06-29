using DevMeet.Services;
using DevMeetData.DTO;
using DevMeetData.Models;
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
        private readonly IBookingItemService _bookingItemService;

        public BookingItemsController(IBookingItemService bookingItemService)
        {
            _bookingItemService = bookingItemService;
        }

        // GET: api/BookingItems
        [HttpGet]
        public async Task<IEnumerable<BookingItemDTO>> GetBookingItems()
        {
            return await _bookingItemService.GetBookingItems();
        }

        // GET: api/BookingItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingItemDTO>> GetBookingItem(int id)
        {
            var bookingItem = await _bookingItemService.Get(id);

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

            BookingItemDTO updatedBookingItem = new BookingItemDTO();

            try
            {
                updatedBookingItem = await _bookingItemService.Update(bookingItem);
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
        public async Task<ActionResult<BookingItemDTO>> PostBookingItem(BookingItem bookingItem)
        {
            return await _bookingItemService.Add(bookingItem);
        }

        // DELETE: api/BookingItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingItemDTO>> DeleteBookingItem(int id)
        {
            var bookingItem = await _bookingItemService.Delete(id);
            if (bookingItem == null)
            {
                return NotFound();
            }
            return bookingItem;
        }

        private bool BookingItemExists(int id)
        {
            return _bookingItemService.BookingItemExists(id);
        }
    }
}
