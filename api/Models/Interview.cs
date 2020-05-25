using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace api.Models
{
    public class Interview
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public Interviewee Interviewee { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [Range(0, 10)]
        public int Rating { get; set; }

        [Required]
        public ICollection<InterviewQuestions> Questions { get; set; }

        public ICollection<InterviewAndInterviewees> Interviewers { get; set; }

    }
}