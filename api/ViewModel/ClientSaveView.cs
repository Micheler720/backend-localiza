using System;

namespace ViewModel
{
    public record ClientSaveView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cpf { get; set; }
        public string Password { get; set; }
        public DateTime Birthay { get; set; }
    }
}