using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Daber_5edma_api.Models;

namespace Daber_5edma_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOffersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobOffersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/JobOffers
        [HttpGet("get-all-joboffers")]
        public async Task<ActionResult<IEnumerable<JobOffer>>> GetJobOffers()
        {
          if (_context.JobOffers == null)
          {
              return NotFound();
          }
            return await _context.JobOffers.ToListAsync();
        }

        // GET: api/JobOffers/5
        [HttpGet("get-joboffer-by-id/{id}")]
        public async Task<ActionResult<JobOffer>> GetJobOffer(int id)
        {
          if (_context.JobOffers == null)
          {
              return NotFound();
          }
            var jobOffer = await _context.JobOffers.FindAsync(id);

            if (jobOffer == null)
            {
                return NotFound();
            }

            return jobOffer;
        }

        // PUT: api/JobOffers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("edit-joboffer/{id}")]
        public async Task<IActionResult> PutJobOffer(int id, JobOffer jobOffer)
        {
            if (id != jobOffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobOfferExists(id))
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

        // POST: api/JobOffers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create-joboffer")]
        public async Task<ActionResult<JobOffer>> PostJobOffer(JobOffer jobOffer)
        {
          if (_context.JobOffers == null)
          {
              return Problem("Entity set 'AppDbContext.JobOffers'  is null.");
          }
            _context.JobOffers.Add(jobOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobOffer", new { id = jobOffer.Id }, jobOffer);
        }

        // DELETE: api/JobOffers/5
        [HttpDelete("delete-joboffer/{id}")]
        public async Task<IActionResult> DeleteJobOffer(int id)
        {
            if (_context.JobOffers == null)
            {
                return NotFound();
            }
            var jobOffer = await _context.JobOffers.FindAsync(id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            _context.JobOffers.Remove(jobOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobOfferExists(int id)
        {
            return (_context.JobOffers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
