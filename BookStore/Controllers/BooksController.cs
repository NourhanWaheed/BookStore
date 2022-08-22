using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreData.Data;
using StoreData.Interfaces;
using StoreData.Models;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBook _context;

        public BooksController(IBook context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var Books = await _context.GetAllAsync("SELECT * FROM Book");
            if (Books.Count() == 0)
                return NotFound();
            return Ok(Books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            if (id == 0)
                return BadRequest();
            var Book = await _context.GetByIdAsync("SELECT * FROM Book WHERE ID =@id", id);
            if (Book == null)
            {
                return NotFound();
            }
            return Book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            await _context.UpdateAsync(id, book);

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            try
            {
                await _context.AddAsync(book);
            }
            catch
            {
                return BadRequest();
            }
            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _context.DeleteAsync(id);
            return NoContent();
        }
    }
}
