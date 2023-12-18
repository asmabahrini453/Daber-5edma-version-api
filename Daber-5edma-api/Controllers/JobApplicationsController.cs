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
    public class JobApplicationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobApplicationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/JobApplications
        [HttpGet("get-all-jobapplications")]
        public async Task<ActionResult<IEnumerable<JobApplication>>> GetJobApplications()
        {
          if (_context.JobApplications == null)
          {
              return NotFound();
          }
            return await _context.JobApplications.ToListAsync();
        }

        // GET: api/JobApplications/5
        [HttpGet("get-jobapplication-by-id/{id}")]
        public async Task<ActionResult<JobApplication>> GetJobApplication(int id)
        {
          if (_context.JobApplications == null)
          {
              return NotFound();
          }
            var jobApplication = await _context.JobApplications.FindAsync(id);

            if (jobApplication == null)
            {
                return NotFound();
            }

            return jobApplication;
        }

        // PUT: api/JobApplications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("edit-jobapplication/{id}")]
        public async Task<IActionResult> PutJobApplication(int id, JobApplication jobApplication)
        {
            if (id != jobApplication.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobApplicationExists(id))
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

        // POST: api/JobApplications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create-jobapplication")]
        public async Task<ActionResult<JobApplication>> PostJobApplication(JobApplication jobApplication)
        {
          if (_context.JobApplications == null)
          {
              return Problem("Entity set 'AppDbContext.JobApplications'  is null.");
          }
            _context.JobApplications.Add(jobApplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobApplication", new { id = jobApplication.Id }, jobApplication);
        }

        // DELETE: api/JobApplications/5
        [HttpDelete("delete-jobapplication/{id}")]
        public async Task<IActionResult> DeleteJobApplication(int id)
        {
            if (_context.JobApplications == null)
            {
                return NotFound();
            }
            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            _context.JobApplications.Remove(jobApplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobApplicationExists(int id)
        {
            return (_context.JobApplications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
