using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("checklists")]
    public class CheckList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool CleanCar { get; set; }

        [Required]
        public bool FullTank { get; set; }

        [Required]
        public bool TankLightsPendant { get; set; }

        [Required]
        public bool Crumpled { get; set; }

        [Required]
        public bool Scratches { get; set; }
        
        public Appointment Appointment { get; set; }

    }
}