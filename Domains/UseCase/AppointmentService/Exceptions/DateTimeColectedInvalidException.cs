using System;

namespace Domains.UseCase.AppointmentService.Exceptions
{
    [Serializable]
    public class DateTimeColectedInvalidException : Exception
    {
        public DateTimeColectedInvalidException(string message): base(message)
        {
            
        }
    }
}