using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksCatalogueAPI.Data;
using BooksCatalogueAPI.Models;

namespace BooksCatalogueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MyDatabaseContext _context;

        public BooksController(MyDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            return await _context.Book
                .Include(b => b.Reviews)
                .AsNoTracking()
                .ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Book
                .Include(b => b.Reviews)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, [FromForm]BookViewModel book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var newBook = new Book
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Synopsis = book.Synopsis,
                ReleaseYear = book.ReleaseYear,
                CoverURL = book.CoverURL
            };

            _context.Entry(newBook).State = EntityState.Modified;
            _context.Entry(newBook).Property(b => b.CoverURL).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromForm]BookViewModel book)
        {
            var newBook = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Synopsis = book.Synopsis,
                ReleaseYear = book.ReleaseYear,
                CoverURL = book.CoverURL
            };
            
            _context.Book.Add(newBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
