using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace api.Models
{
    public class Interviewer : Person
    {

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}