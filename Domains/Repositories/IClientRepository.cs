using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Domains.Repositories
{
    public interface IClientRepository<Client> : IBaseRepository<Client> where Client : class
    {
        Task<Client> FindByPersonRegisterNot(Client user);
        Task<Client> FindById(int id);
        Task<Client> FindByCpfAndPassword(string cpf, string password);
        Task<List<Client>> FindByClient();
    }
}