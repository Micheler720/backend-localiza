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
        public DateTime DateTimeExpectedCollected { get; set; }
        
        public DateTime? DateTimeCollected { get; set; }

        [Required]
        public DateTime DateTimeExpectedDelivery { get; set; }

        public DateTime? DateTimeDelivery { get; set; }

        [Required]
        public Double HourPrice { get; set; }

        [Required]
        public int HourLocation { get; set; }

        public Double Subtotal { get; set; }

        public Double AdditionalCosts {get; set; }

        [Required]
        public Double Amount {get; set; }

        [Required]
        public bool Inspected { get; set; }   

        [Required]
        public int IdClient { get; set; }   

        public Client Client { get; set; }

        [Required]
        public int IdCar { get; set; } 

        public Car Car { get; set; }

        [Required]
        public int IdOperator { get; set; }  

        public Operator Operator { get; set; }   
             
        public int? IdCheckList { get; set; }
        public CheckList CheckList { get; set; }
    }
}