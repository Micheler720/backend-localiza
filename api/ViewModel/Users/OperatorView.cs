using System;

namespace ViewModel.Users
{
    public record OperatorView
    {
        public int Id { get; set; }
        public string Name { get; set; }             
        public string Registration { get; set; }
    }
}