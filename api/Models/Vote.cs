using System.ComponentModel.DataAnnotations;
namespace api.Models{
    public class Vote
{
    [Required]
    [Key]
    public int Id { get; set; }

    [Required]
    public int Value { get; set; }

    [StringLength(500)]
    public string Comment { get; set; }

    [Required]
    public Response Answer { get; set; }
}
}