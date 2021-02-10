using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using  Domains.User.Interfaces;


namespace Domains.User
{
    [Table("users")]
    public class Operator : IUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Registration { get; set; }
    }
}