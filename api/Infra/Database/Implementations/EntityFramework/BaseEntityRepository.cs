using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Infra.Database.Repositories;

namespace Infra.Database.Implementations.EntityFramework.Repositories
{
    public class BaseEntityRepository<T> : IBaseRepository<T> where T : class
    {
        protected ContextEntity _context;
        public BaseEntityRepository(ContextEntity context)
        {
         this._context = context;   
        }
        public void Add(T entity)
        {
            
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] expressions)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] expressions)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
    }
}