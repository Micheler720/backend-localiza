using Entities;
using Entities.Interfaces;

namespace Domains.Interfaces
{
    public interface IToken
    {
        string TokenGenerateClient(Client client);
        string TokenGenerateOperator(Operator op);
    }
}