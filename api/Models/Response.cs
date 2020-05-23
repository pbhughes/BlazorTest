using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace api.Models
{
    public class Response
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        [Required]
        public Question Question { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}