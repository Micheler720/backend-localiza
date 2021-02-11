using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Interfaces;
using Entities.Roles;

namespace Entities
{
    
    [Table("users")]
    public class Operator : IUser, IOperator
    {
        private UserRole _userRole;

        public Operator()
        {
            this._userRole = UserRole.Operator;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set;}

        [Required]
        [MaxLength(15)]
        public string Password { get; set; }

        [Required]
        public UserRole UserRole
        {
            get
            { 
                return _userRole;
            }
        }
        
        [MaxLength(9)]
        public string Registration { get; set; }
    }
}