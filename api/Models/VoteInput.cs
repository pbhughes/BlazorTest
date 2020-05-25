using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace api.Models{
    /// <summary>
    /// Data transfer input class for a vote object
    /// </summary>
    /// 
    /// 
    /// 
        [NotMappedAttribute]
        public class VoteInput{

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
    }
}
