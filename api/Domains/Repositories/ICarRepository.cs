using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domains.Repositories
{
    public interface ICarRepository<Car> : IBaseRepository<Car> where Car : class
    {
        
        Task<Car> FindById(int id);
        Task<Car> FindByBoard(string board);
        Task<Car> FindByIsBoardNotId(Car car);
    }
}