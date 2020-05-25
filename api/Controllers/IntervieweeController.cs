using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntervieweeController : ControllerBase
    {
        private readonly InterviewSqlData _context;

        public IntervieweeController(InterviewSqlData context)
        {
            _context = context;
        }

        // GET: api/Interviewee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interviewee>>> GetInterviewees()
        {
            return await _context.Interviewees.ToListAsync();
        }

        // GET: api/Interviewee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interviewee>> GetInterviewee(int id)
        {
            var interviewee = await _context.Interviewees.FindAsync(id);

            if (interviewee == null)
            {
                return NotFound();
            }

            return interviewee;
        }

        // PUT: api/Interviewee/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterviewee(int id, Interviewee interviewee)
        {
            if (id != interviewee.Id)
            {
                return BadRequest();
            }

            _context.Entry(interviewee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntervieweeExists(id))
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

        // POST: api/Interviewee
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Interviewee>> PostInterviewee(Interviewee interviewee)
        {
            _context.Interviewees.Add(interviewee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterviewee", new { id = interviewee.Id }, interviewee);
        }

        // DELETE: api/Interviewee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interviewee>> DeleteInterviewee(int id)
        {
            var interviewee = await _context.Interviewees.FindAsync(id);
            if (interviewee == null)
            {
                return NotFound();
            }

            _context.Interviewees.Remove(interviewee);
            await _context.SaveChangesAsync();

            return interviewee;
        }

        private bool IntervieweeExists(int id)
        {
            return _context.Interviewees.Any(e => e.Id == id);
        }
    }
}
