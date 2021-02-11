using System;

namespace Domains.UseCase.UserServices.Exceptions
{
    [Serializable]
    public class UserNotDefinid: Exception
    {
        public UserNotDefinid(string message) : base(message) { }
        
    }
}