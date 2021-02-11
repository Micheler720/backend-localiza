using System.Linq;
using Domains.Repositories;
using Entities.Interfaces;

namespace Infra.Database.Implementations.EntityFramework.Repositories.UsersRespository
{
    public class UserRepository :  BaseEntityRepository<IUser>, IUserRepository<IUser>
    {
        public UserRepository(ContextEntity context) : base(context)
        {

        }

    }
}