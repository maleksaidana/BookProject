using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers {
  


    [Route("api/[controller]/[action]")]
    [ApiController]
   

    public class BooksController : ControllerBase
    {

        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return  await _context.books.Include(s => s.history).AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(long id)
        {
            return await _context.books.Include(s => s.history).AsNoTracking().SingleOrDefaultAsync(i => i.id == id); ;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> createBook(Book book)
        {
            _context.books.Add(book);
            await _context.SaveChangesAsync();

            return await _context.books.Include(s => s.history).AsNoTracking().SingleOrDefaultAsync(i => i.id == book.id); ;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> addHistory(BookHistory hist)
        {
            _context.historys.Add(hist);
            await _context.SaveChangesAsync();

          

            return await _context.books.Include(s => s.history).AsNoTracking().SingleOrDefaultAsync(i => i.id == hist.BookId); ;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            var book = await _context.books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}