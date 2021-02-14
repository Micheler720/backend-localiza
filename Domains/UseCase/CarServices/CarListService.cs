using System.Collections.Generic;
using System.Threading.Tasks;
using Domains.Repositories;
using Entities;

namespace Domains.UseCase.CarServices
{
    public class CarListService
    {
        private ICarRepository<Car> _repository;
        
        public CarListService(ICarRepository<Car> repository)
        {
            this._repository = repository;
        }

        public async Task<List<Car>> Execute ()
        {
            return await _repository.GetAll();
        }
    }
}