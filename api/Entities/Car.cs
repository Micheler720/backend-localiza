using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(8)]
        public string Placa { get; set; }

        [Required]
        public Double HourPrice { get; set; }

        [Required]
        public int LuggageCapacity { get; set; }

        [Required]
        public int TankCapacity { get; set; }

        [Required]
        public int IdBrand {get; set; }

        public CarBrand Brand { get; set; }

        [Required]
        public int IdCategory {get; set; }

        public CarCategory Category { get; set; }

        [Required]
        public int IdFuel {get; set; }

        public CarFuel Fuel { get; set; }

        [Required]
        public int IdModel {get; set; }

        public CarModel Model { get; set; }
    }
}