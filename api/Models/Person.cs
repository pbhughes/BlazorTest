using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace api.Models
{
    public class Person
    {

        [Key]
        /// <summary>
        /// Primary key identifier for the person
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        /// <summary>
        /// The persons name
        /// </summary>
        /// <example>Johh Doe</example>
        /// <value>200 character string containing the person's full name</value>
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        /// <summary>
        /// The persons email address
        /// </summary>
        /// <example>john.doe@gmail.com</example>
        /// <value>A compliant email address as a string with a user@domain.com configuration</value>
        public string Email { get; set; }
    }
}