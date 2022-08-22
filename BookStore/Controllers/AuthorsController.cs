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
        public async Task<IActionResult> GetAuthors()
        {
            var Authors = await _context.GetAllAsync("SELECT * FROM Author");
            if(Authors.Count() == 0)
                return NotFound();
            return Ok(Authors) ;
        }

        //GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            if(id == 0)
                return BadRequest();
            var Author = await _context.GetByIdAsync("SELECT * FROM Author WHERE ID =@id" , id);
            if (Author == null)
            {
                return NotFound();
            }
            return Author;
        }

        //// PUT: api/Authors/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }
            await _context.UpdateAsync(id, author);

            return NoContent();
        }

        //// POST: api/Authors
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            try
            {
                await _context.AddAsync(author);
            }
            catch
            {
                return BadRequest();
            }
           return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        //// DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
           await _context.DeleteAsync(id);
            return NoContent();
        }
    }
}
