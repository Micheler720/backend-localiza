using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Interfaces;

namespace Entities
{
    [Table("users")]
    public class User : IOperator, IPerson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        
        [MaxLength(11)]
        public string CPF { get; set; }      
        
        public DateTime Birthay { get; set; }
        public string Registration { get; set; }

        [Required]        
        [MaxLength(15)]
        public string Password { get; set; }
        
    }
}