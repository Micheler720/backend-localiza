using System;

namespace Entities.Interfaces
{
    public interface IPerson
    {
        string Cpf { get; set; }
        DateTime Birthay { get; set; }
    }
}