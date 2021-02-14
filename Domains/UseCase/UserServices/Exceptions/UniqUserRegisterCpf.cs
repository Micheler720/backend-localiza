using System;
using System.Runtime.Serialization;

namespace Domains.UseCase.UserServices.Exceptions
{
    [Serializable]
    public class UniqUserRegisterCpf : Exception
    {
        public UniqUserRegisterCpf(string message) : base(message) { }
    }
}