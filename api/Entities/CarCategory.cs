using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("car_categories")]
    public class CarCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Category { get; set; }
        public List<Car> Cars { get; set; }

    }
}