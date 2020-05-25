using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace api.Models
{
    /// <summary>
    /// Records a vote on how well the interviewee answered a particular question
    /// </summary>
    public class Vote
    {
        /// <summary>
        /// Unique id for the vote
        /// </summary>
        /// <example>1</example>
        /// <value>The id for the vote</value>
        [Key]
        [Display(AutoGenerateField=true)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        /// <summary>
        /// Vote magnitude: The higher the number the higher score the better the interview.null  A vote 
        /// is tracked to a <see cref="Question" /> 1 is the minimum or not so good and 10 is the maximum, so the best
        /// </summary>
        /// <example>10</example>
        /// <value>Gets / sets the magnitude of the score for the vote</value>
        [Required]
        [Range(1, 10)]
        public int Value { get; set; }

        /// <summary>
        /// Justification for the magnitude
        /// </summary>
        /// <example>I really liked this guys response</example>
        /// <value>Gets / sets a string fortTextual comments about why the voter voted with the current magnitude</value>
        [StringLength(500)]
        public string Comment { get; set; }

        /// <summary>
        /// The question the vote is associate to
        /// </summary>
        /// <value>Gets / sets the question the vote was taken for</value>
        [Required]
        [Browsable(false)]
        [XmlIgnore]
        [JsonIgnore]
        public Question Question { get; set; }

        /// <summary>
        /// The person asking the question
        /// </summary>
        /// <value>Gets / sets the person asking the question</value>
        [Required]
        [Browsable(false)]
        [XmlIgnore]
        [JsonIgnore]
        public Interviewer Interviewer { get; set; }
    }
}