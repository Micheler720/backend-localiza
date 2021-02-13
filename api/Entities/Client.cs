using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Interfaces;
using Entities.Roles;

namespace Entities
{
    [Table("users")]
    public class Client : IUser, IPerson
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(11)]
        public string Cpf { get; set; }

        public DateTime Birthay { get; set; }

        [Required]
        [MaxLength(15)]
        public string Password { get; set; }

        [Required]
        public UserRole UserRole { get; set; }
        
    }
}