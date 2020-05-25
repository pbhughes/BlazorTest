using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace api.Models{
    public class Interviewee : Person
{
    [Phone]
    public string Phone { get; set; }

    public ICollection<Interview> Interviews { get; set; }
}
}