using System.ComponentModel.DataAnnotations;
namespace api.Models{
    public class Person
{
    [Required]
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
}