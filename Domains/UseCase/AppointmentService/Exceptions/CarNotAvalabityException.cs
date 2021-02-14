using System;

namespace Domains.UseCase.AppointmentService.Exceptions
{
    [Serializable]
    public class CarNotAvalabityException : Exception
    {
         public CarNotAvalabityException(string message) : base(message) { }
    }
}