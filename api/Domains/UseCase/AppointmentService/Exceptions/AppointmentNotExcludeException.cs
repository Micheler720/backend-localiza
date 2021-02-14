using System;

namespace Domains.UseCase.AppointmentService.Exceptions
{
    [Serializable]
    public class AppointmentNotExcludeException : Exception
    {
        public AppointmentNotExcludeException(string message) : base(message)
        {
            
        }
    }
}