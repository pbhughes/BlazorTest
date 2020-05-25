using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace api.Models
{
    public class Interviewer : Person
    {

        [Required]
        [StringLength(200)]
        /// <summary>
        /// The interviewers formal job title
        /// </summary>
        /// <example>Manager of Accounting</example>
        /// <remarks>
        /// A 200 character string denoting the person's job title
        /// </remarks>
        /// <value>200 character string containing the person's job title</value>
        public string Title { get; set; }

        /// <summary>
        /// Collection of votes the user has made
        /// </summary>
        /// <example>
        /// <code>
        /// { votes: [] }
        /// </code>
        /// </example>
        /// <remarks>
        /// A collection of <see cref="api.Models.Vote"/> the user has made, if the user new votes are null { votes: [] }
        /// </remarks>
        /// <value>An array of votes the user has made <see cref="api.Models.Vote"/></value>
        public ICollection<Vote> Votes { get; set; }

        /// <summary>
        /// A collection of intervies the user has done
        /// </summary>
        /// <example>
        /// <code>
        /// { Interviews : [] }
        /// </code>
        /// </example>
        /// <remarks>
        /// A collection of <see cref="api.Models.Interview"/> the user has done, if new interviews will be null { interviews: []}
        /// </remarks>
        /// <value>An array of <see cref="api.Models.Interview"/></value>
        public ICollection<InterviewAndInterviewees> Interviews { get; set; }


    }
}