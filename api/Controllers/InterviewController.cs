using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using api.Models;
//using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<InterviewController> _logger;
        public InterviewController(IConfiguration config, ILogger<InterviewController> logger)
        {
            _config = config;
            _logger = logger;
        }

        // GET api/interview
        [HttpGet("")]
        public ActionResult<IEnumerable<Interview>> Getstrings()
        {
            return new List<Interview> { };
        }

        // GET api/interview/5
        [HttpGet("{id}")]
        public ActionResult<Interview> GetstringById(int id)
        {
            return null;
        }

        // POST api/interview
        [HttpPost("")]
        public void Poststring(string value)
        {
        }

        // PUT api/interview/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value)
        {
        }

        // DELETE api/interview/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id)
        {
        }
    }
}