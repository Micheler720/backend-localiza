using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using  Domains.User.Interfaces;

namespace Domains.User.Interfaces
{
    [Table("users")]
    public class Client : IUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Cpf { get; set; }
    }
}