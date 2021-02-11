using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domains.Repositories
{
    public interface IBaseRepository<T>
    {        
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] expressions);
        Task<List<T>> Filter(
            Expression<Func<T, bool>> where,
            params Expression<Func<T, object>>[] expressions
        );
    }
}