using System.Runtime.CompilerServices;
using System.Reflection.Metadata.Ecma335;
using System.Net;
using System.Threading;
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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly InterviewSqlData _context;

        public VoteController(InterviewSqlData context)
        {
            _context = context;
        }

        // GET: api/Vote
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Vote>>> GetVotes()
        {
            return await _context.Votes.ToListAsync();
        }

        // GET: api/Vote/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vote>> GetVote(int id)
        {
            var vote = await _context.Votes.FindAsync(id);

            if (vote == null)
            {
                return NotFound();
            }

            return vote;
        }

        // PUT: api/Vote/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Records a vote on a question, so the question ID is required
        /// </summary>
        /// <param name="questionId">An integer id field identifing the question the vote belongs to</param>
        /// <param name="vote">The vote data </param>
        /// <param name="interviewerId">The id of the interviewer making the assesment</param>
        /// <returns></returns>
        [HttpPut("{questionId}/{interviewerId}")]
        public async Task<IActionResult> PutVote( [FromRoute] int questionId, [FromRoute] int interviewerId,  [FromBody] VoteInput vote)
        {
            if(! ModelState.IsValid )
            {
                return BadRequest(ModelState);
            }

            var question = await _context.Questions.Where( q => q.ID == questionId).FirstOrDefaultAsync();
           
            if(question == null)
            {
                return BadRequest( $"Question {questionId} does not exist, you have to have a valid question to vote on.");
            }

          var interviewer = await _context.Interviewers.Where( i => i.Id == interviewerId).FirstOrDefaultAsync();
            
            if(interviewer == null){
                return BadRequest($"Interviewer with interview ID {interviewerId} does not exit, you have associate a vote to an interviewer");
            }

           
            try
            {
                Vote v = new Vote(){
                    Comment = vote.Comment,
                    Value = vote.Value,
                    Question = question,
                    Interviewer = interviewer
                };

                await _context.Votes.AddAsync(v);
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteExists(vote.Id))
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

        // POST: api/Vote
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vote>> PostVote(Vote vote)
        {
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVote", new { id = vote.Id }, vote);
        }

        // DELETE: api/Vote/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vote>> DeleteVote(int id)
        {
            var vote = await _context.Votes.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }

            _context.Votes.Remove(vote);
            await _context.SaveChangesAsync();

            return vote;
        }

        private bool VoteExists(int id)
        {
            return _context.Votes.Any(e => e.Id == id);
        }
    }
}
