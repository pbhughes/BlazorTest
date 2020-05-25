using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace api.Models{
    public class InterviewAndInterviewees{
        public int InterviewId { get; set; }

        public Interview Interview { get; set; }

        public int InterviewerId { get; set; }

        public Interviewer Interviewer { get; set; }

    }
}