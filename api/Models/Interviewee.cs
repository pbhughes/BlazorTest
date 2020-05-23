using System.ComponentModel.DataAnnotations;

namespace api.Models{
    public class Interviewee : Person
{
    [Phone]
    public string Phone { get; set; }
}
}