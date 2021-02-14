using System;
using System.Threading.Tasks;
using Entities;

namespace Domains.Repositories
{
    public interface IChecklistRepository<CheckList> : IBaseRepository<CheckList> where CheckList : class
    {
        Task<CheckList> FindById(int id);
    }
}