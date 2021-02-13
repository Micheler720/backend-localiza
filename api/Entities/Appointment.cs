using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Schedule { get; set; }

        [Required]
        public DateTime DateTimeExpectedCollection { get; set; }

        [Required]
        public DateTime DateTimeCollected { get; set; }

        [Required]
        public DateTime DateTimeExpectedDelivery { get; set; }
        public DateTime DateTimeDelivery { get; set; }

        [Required]
        public Double HourPrice { get; set; }

        [Required]
        public int HourLocation { get; set; }

        public Double Subtotal { get; set; }

        public Double AdditionalCosts {get; set; }

        public CarCategory Category { get; set; }

        [Required]
        public Double Amount {get; set; }

        [Required]
        public bool Inspected { get; set; }   

        [Required]
        public int IdClient { get; set; }   

        public List<Client> Clients { get; set; }

        [Required]
        public int IdCar { get; set; } 

        [Required]
        public int IdOperator { get; set; }    

        [Required]
        public int IdCheckList { get; set; } 
    }
}