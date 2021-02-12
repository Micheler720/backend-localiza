using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("cars_brands")]
    public class CarsBrands
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(150)]
        public int Name { get; set; }

    }
}