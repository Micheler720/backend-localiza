using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domains.Repositories
{
    public interface IUserRepository<User> : IBaseRepository<User> where User : class
    {
        Task<User> FindByOperatorRegisterNot(User user);
        Task<User> FindByPersonRegisterNot(User user);
        Task<User> FindById(int id);
        Task<User> FindByCpfAndPassword(string cpf, string password);
        Task<User> FindByRegistrationAndPassword(string registration, string password);
    }
}