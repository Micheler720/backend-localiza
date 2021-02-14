using System;

namespace Shared.Exceptions
{
    [Serializable]

    public class RegisterExistException : Exception
    {
        public RegisterExistException(string message) : base (message) { }        
    }
}