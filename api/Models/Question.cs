using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace api.Models
{
    public class Question
    {

        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        [Required]
        public string OptimalResponseText { get; set; }

        public string ActualResponseText { get; set; }

        public ICollection<Vote> Votes { get; set; }

        [Required]
        [Browsable(false)]
        [XmlIgnore]
        [JsonIgnore]
        public ICollection< InterviewQuestions > Interviews { get; set; }


    }
}