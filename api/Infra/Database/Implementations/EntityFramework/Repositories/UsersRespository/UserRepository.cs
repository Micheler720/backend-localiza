using System.Linq;
using Domains.Repositories;
using Entities;
using Infra.Database.Implementations.EntityFramework.Repositories;

namespace Infra.Database.Implementations.EntityFramework.Repositories.UsersRespository
{
    public class UserRepository :  BaseEntityRepository<User>, IUserRepository<User>
    {
        public UserRepository(ContextEntity context) : base(context)
        {

        }

    }
}