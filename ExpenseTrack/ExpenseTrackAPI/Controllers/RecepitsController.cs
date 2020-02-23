using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackAPI.Models;

namespace ExpenseTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepitsController : ControllerBase
    {
        private readonly ExpenseContext _context;

        public RecepitsController(ExpenseContext context)
        {
            _context = context;
        }

        // GET: api/Recepits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recepit>>> GetRecepits()
        {
            return await _context.Recepits.ToListAsync();
        }

        // GET: api/Recepits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recepit>> GetRecepit(long id)
        {
            var recepit = await _context.Recepits.FindAsync(id);

            if (recepit == null)
            {
                return NotFound();
            }

            return recepit;
        }

        // PUT: api/Recepits/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecepit(long id, Recepit recepit)
        {
            if (id != recepit.Id)
            {
                return BadRequest();
            }

            _context.Entry(recepit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecepitExists(id))
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

        // POST: api/Recepits
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Recepit>> PostRecepit(Recepit recepit)
        {
            _context.Recepits.Add(recepit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecepit", new { id = recepit.Id }, recepit);
        }

        // DELETE: api/Recepits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recepit>> DeleteRecepit(long id)
        {
            var recepit = await _context.Recepits.FindAsync(id);
            if (recepit == null)
            {
                return NotFound();
            }

            _context.Recepits.Remove(recepit);
            await _context.SaveChangesAsync();

            return recepit;
        }

        private bool RecepitExists(long id)
        {
            return _context.Recepits.Any(e => e.Id == id);
        }
    }
}
