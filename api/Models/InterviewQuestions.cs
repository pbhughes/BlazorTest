using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models{
    public class InterviewQuestions{
        public int InterviewId { get; set; }

        public Interview Interview { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}