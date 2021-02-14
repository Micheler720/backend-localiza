using System;

namespace Domains.UseCase.UserServices.Exceptions
{
    [Serializable]
    public class UserNotFound: Exception
    {
        public UserNotFound(string message) : base(message) { }
        
    }
}