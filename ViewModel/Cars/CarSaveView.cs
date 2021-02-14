using System;

namespace ViewModel.Cars
{
    public record CarSaveView
    {
        public int Id { get; set; }
        public string Board { get; set; }
        public Double HourPrice { get; set; }
        public int LuggageCapacity { get; set; }
        public int TankCapacity { get; set; }
        public int IdBrand {get; set; }
        public int IdCategory {get; set; }
        public int IdFuel {get; set; }
        public int IdModel {get; set; }
    }
}