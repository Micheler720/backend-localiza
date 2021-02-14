using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Repositories;
using Entities;
using Entities.Interfaces;
using Entities.Roles;
using Microsoft.EntityFrameworkCore;


namespace Infra.Database.Implementations.EntityFramework.Repositories.CarsRepository
{
    public class CarRepositoryEntity : BaseEntityRepository<Car>, ICarRepository<Car>
    {

        public CarRepositoryEntity(ContextEntity context) : base(context)
        {

            this._context = context;

        }

        public async Task<Car> FindByBoard(string board)
        {
            var query = from c in this._context.Cars
                where  board == c.Board
                select c;
            return await query.FirstOrDefaultAsync<Car>() as Car;
        }

        public async Task<Car> FindById(int id)
        {
            var query = from c in this._context.Cars
                where  id == c.Id
                select c;
            return await query.FirstOrDefaultAsync<Car>() as Car;
        }

        public async Task<Car> FindByIsBoardNotId(Car car)
        {
            var query = from c in this._context.Cars
                where  car.Board == c.Board
                && car.Id != c.Id
                select c;
            return await query.FirstOrDefaultAsync<Car>() as Car;
        }
    }
}