using System;

namespace ViewModel
{
    public record ClientView
    {
        public int Id { get; set; }
        public string Name { get; set; }             
        public DateTime Birthay { get; set; }
        public string Cpf { get; set; }
    }
}