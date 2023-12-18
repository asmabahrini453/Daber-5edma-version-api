using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Daber_5edma_api.Models;
using System.ComponentModel.DataAnnotations;

namespace Daber_5edma_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CandidatsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Candidats
        [HttpGet("get-all-Candidats")]
        public async Task<ActionResult<IEnumerable<Candidat>>> GetCandidats()
        {
          if (_context.Candidats == null)
          {
              return NotFound();
          }
            return await _context.Candidats.ToListAsync();
        }

        // GET: api/Candidats/5
        [HttpGet("get-Candidat-by-id/{id}")]
        public async Task<ActionResult<Candidat>> GetCandidat(int id)
        {
          if (_context.Candidats == null)
          {
              return NotFound();
          }
            var candidat = await _context.Candidats.FindAsync(id);

            if (candidat == null)
            {
                return NotFound();
            }

            return candidat;
        }

        // PUT: api/Candidats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("edit-candidat/{id}")]
        public async Task<IActionResult> PutCandidat(int id, Candidat candidat)
        {
            if (id != candidat.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatExists(id))
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

        // POST: api/Candidats/create-candidat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create-candidat")]
        public async Task<ActionResult<Candidat>> PostCandidat(Candidat candidat)
        {
          if (_context.Candidats == null)
          {
              return Problem("Entity set 'AppDbContext.Candidats'  is null.");
          }
            _context.Candidats.Add(candidat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidat", new { id = candidat.Id }, candidat);
        }

        // DELETE: api/Candidats/5
        [HttpDelete("delete-candidat/{id}")]
        public async Task<IActionResult> DeleteCandidat(int id)
        {
            if (_context.Candidats == null)
            {
                return NotFound();
            }
            var candidat = await _context.Candidats.FindAsync(id);
            if (candidat == null)
            {
                return NotFound();
            }

            _context.Candidats.Remove(candidat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidatExists(int id)
        {
            return (_context.Candidats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
