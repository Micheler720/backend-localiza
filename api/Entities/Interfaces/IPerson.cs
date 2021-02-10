using System;

namespace Entities.Interfaces
{
    public interface IPerson
    {
        string CPF { get; set; }
        DateTime Birthay { get; set; }
    }
}