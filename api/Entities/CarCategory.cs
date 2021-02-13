using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domains.Interfaces;

namespace Entities
{
    [Table("car_categories")]
    public class CarCategory 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public List<Car> Cars { get; set; }

    }
}