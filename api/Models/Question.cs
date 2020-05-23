
using System.ComponentModel.DataAnnotations;
namespace api.Models{
    public class Question
{

    [Required]
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(500)]
    public string Text { get; set; }

    [Required]
    public Response OptimalResponse { get; set; }

    public Response ActualResponse { get; set; }
}
}