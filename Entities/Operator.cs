using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Interfaces;
using Entities.Roles;

namespace Entities
{
    
    [Table("operators")]
    public class Operator : IUser, IOperator
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set;}

        [Required]
        [MaxLength(15)]
        public string Password { get; set; }
        
        [Required]
        public UserRole UserRole { get; set; }
        
        [MaxLength(9)]
        public string Registration { get; set; }
        
        public List<Appointment> Appointments { get; set;}
    }
}