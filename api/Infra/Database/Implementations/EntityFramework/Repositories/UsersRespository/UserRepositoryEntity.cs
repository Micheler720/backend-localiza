using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Repositories;
using Entities;
using Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Implementations.EntityFramework.Repositories.UsersRespository
{
    public class UserRepositoryEntity :  BaseEntityRepository<User>, IUserRepository<User>
    {
        
        public UserRepositoryEntity(ContextEntity context) : base(context)
        {

            this._context = context;

        }
        public async Task<User> FindByOperatorRegisterNot( User user)
        {
             var query = from u in _context.Users
                where u.Registration ==  user.Registration
                && user.Id != u.Id
                select u;
            return await query.FirstOrDefaultAsync<User>() as User;
        }

        public async Task<User> FindByPersonRegisterNot( User user)
        {
             var query = from u in _context.Users
                where u.Cpf ==  user.Cpf
                && user.Id != u.Id
                select u;
            return await query.FirstOrDefaultAsync<User>() as User;
        }

    }
}