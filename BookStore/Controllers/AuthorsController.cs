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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthor _context;

        public AuthorsController(IAuthor context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult> GetAuthors()
        {
            return(ActionResult) await _context.GetAllAsync("SELECT * FROM Author");
        }

        // GET: api/Authors/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Author>> GetAuthor(int id)
        //{
        //  if (_context.Authors == null)
        //  {
        //      return NotFound();
        //  }
        //    var author = await _context.Authors.FindAsync(id);

        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    return author;
        //}

        //// PUT: api/Authors/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAuthor(int id, Author author)
        //{
        //    if (id != author.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(author).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AuthorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Authors
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Author>> PostAuthor(Author author)
        //{
        //  if (_context.Authors == null)
        //  {
        //      return Problem("Entity set 'StoreContext.Authors'  is null.");
        //  }
        //    _context.Authors.Add(author);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        //}

        //// DELETE: api/Authors/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAuthor(int id)
        //{
        //    if (_context.Authors == null)
        //    {
        //        return NotFound();
        //    }
        //    var author = await _context.Authors.FindAsync(id);
        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Authors.Remove(author);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AuthorExists(int id)
        //{
        //    return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
