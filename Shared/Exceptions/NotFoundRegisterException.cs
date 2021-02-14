using System;

namespace Shared.Exceptions
{
    [Serializable]
    public class NotFoundRegisterException: Exception
    {
        public NotFoundRegisterException(string message) : base(message) { }
        
    }
}