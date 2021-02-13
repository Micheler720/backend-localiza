using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Repositories;
using Entities;
using Entities.Interfaces;
using Entities.Roles;
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

        public async Task<User> FindById(int id)
        {
             var query = from u in _context.Users
                where  id == u.Id
                select u;
            return await query.FirstOrDefaultAsync<User>() as User;
        }

        public async Task<User> FindByCpfAndPassword(string cpf, string password)
        {
            var query = from u in _context.Users
                where  cpf == u.Cpf
                && password == u.Password
                select u;
            return await query.FirstOrDefaultAsync<User>() as User;
        }

        public async Task<User> FindByRegistrationAndPassword(string registration, string password)
        {
            var query = from u in _context.Users
                where  registration == u.Registration
                && password == u.Password
                select u;
            return await query.FirstOrDefaultAsync<User>() as User;
        }

        public async Task<List<User>> FindByClient()
        {
            var userRole = UserRole.Person;
            var query = from u in _context.Users
                where  u.UserRole == userRole
                select u;
            return await query.ToListAsync<User>();
        }

        public async Task<List<User>> FindByOperator()
        {
            var userRole = UserRole.Operator;
            var query = from u in _context.Users
                where  u.UserRole == userRole
                select u;
            return await query.ToListAsync<User>();
        }
    }
}