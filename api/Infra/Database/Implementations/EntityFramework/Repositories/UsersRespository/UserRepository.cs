using System.Linq;
using Entities;
using Infra.Database.Implementations.EntityFramework.Repositories;
using Infra.Database.Repositories.Interfaces;

namespace Infra.Database.Implementations.EntityFramework.Repositories.UsersRespository
{
    public class UserRepository :  BaseEntityRepository<User>, IUserRepository<User>
    {
        public UserRepository(ContextEntity context) : base(context)
        {

        }

    }
}