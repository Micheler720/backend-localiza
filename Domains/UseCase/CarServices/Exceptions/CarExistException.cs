using System;

namespace Domains.UseCase.CarServices.Exceptions
{
    [Serializable]

    public class CarExistException : Exception
    {
        public CarExistException(string message) : base (message) { }        
    }
}