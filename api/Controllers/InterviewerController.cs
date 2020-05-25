using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly InterviewSqlData _context;

        public InterviewerController(InterviewSqlData context)
        {
            _context = context;
        }

        // GET: api/Interviewer
       
        /// <summary>
        /// Gets all the interviewers
        /// </summary>
        /// <returns>An array of interviewers 
        /// </returns>
        /// <response code="200">All interviewers are returned</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">System failed to get interviewers</response>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Interviewer>) , 200)]
        [ProducesResponseType(typeof(IDictionary<string,string>) , 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Interviewer>>> GetInterviewers()
        {
            return await _context.Interviewers.ToListAsync();
        }

        // GET: api/Interviewer/5
        /// <summary>
        /// Gets a particular interviewer
        /// </summary>
        /// <param name="id">The Id of the interviewer your after
        /// </param>
        /// <example>2</example>
        /// <returns><see cref="api.Models.Interview" /></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Interviewer>> GetInterviewer(int id)
        {
            var interviewer = await _context.Interviewers.FindAsync(id);

            if (interviewer == null)
            {
                return NotFound();
            }

            return interviewer;
        }

        // PUT: api/Interviewer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Updates an interviewer in the system
        /// </summary>
        /// <param name="id">THe ID of the interviewer to update</param>
        /// <param name="interviewer">The data for the interviewer to update <see cref="api.Models.Interview" /></param>
        /// <example>
        /// <code>
        /// {
        ///    "title": "string",
        ///     "votes": [],
        ///     "interviews": []
        ///     "name": "string",
        ///     "email": "user@example.com"
        /// }
        /// </code>
        /// </example>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterviewer(int id, Interviewer interviewer)
        {
            if (id != interviewer.Id)
            {
                return BadRequest();
            }

            _context.Entry(interviewer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewerExists(id))
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

        // POST: api/Interviewer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Adds a new interviewer to the system
        /// </summary>
        /// <param name="interviewer">The interviewer to be added to the system <see cref="api.Models.Interview" />
        /// <example>
        /// <code>
        /// {
        ///    "title": "string",
        ///     "votes": [],
        ///     "interviews": []
        ///     "name": "string",
        ///     "email": "user@example.com"
        /// }
        /// </code>
        /// </example>
        /// </param>
        /// <returns><see cref="api.Models.Interview"/></returns>
        [HttpPost]
        public async Task<ActionResult<Interviewer>> PostInterviewer([FromBody] Interviewer interviewer)
        {
            _context.Interviewers.Add(interviewer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterviewer", new { id = interviewer.Id }, interviewer);
        }

        // DELETE: api/Interviewer/5
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Removes an interviewer from the system",
            Description = "Requires admin, all votes for the interviewer will remain",
            OperationId = "DeleteInterviewer",
            Tags = new [] { "Interviewer"}
        )]
        public async Task<ActionResult<Interviewer>> DeleteInterviewer(int id)
        {
            var interviewer = await _context.Interviewers.FindAsync(id);
            if (interviewer == null)
            {
                return NotFound();
            }

            _context.Interviewers.Remove(interviewer);
            await _context.SaveChangesAsync();

            return interviewer;
        }

        private bool InterviewerExists(int id)
        {
            return _context.Interviewers.Any(e => e.Id == id);
        }
    }
}
