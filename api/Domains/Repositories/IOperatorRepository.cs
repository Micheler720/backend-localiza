using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Domains.Repositories
{
    public interface IOperatorRepository<Operator> : IBaseRepository<Operator> where Operator : class
    {
        Task<Operator> FindByOperatorRegisterNot(Operator user);

        Task<Operator> FindById(int id);
        Task<Operator> FindByRegistrationAndPassword(string registration, string password);
        Task<List<Operator>> FindByOperator();
    }
}