using Entities;

namespace Domains.Interfaces
{
    public interface IToken
    {
        string TokenGenerate(User user);
    }
}