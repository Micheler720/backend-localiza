using System.Collections.Generic;
using System.Threading.Tasks;
using Domains.Repositories;
using Entities;
using Domains.UseCase.UserServices.Exceptions;

namespace Domains.UseCase.CarServices
{
    public class CarDeleteService
    {
        private ICarRepository<Car> _repository;
        
        public CarDeleteService(ICarRepository<Car> repository)
        {
            this._repository = repository;
        }

        public async Task Execute (int id)
        {
            if(id == 0) throw new CarNotFoundException("Carro não encontrado.");
            var car = await this._repository.FindById(id);
            if(car == null) throw new CarNotFoundException("Carro não encontrado.");
            await _repository.Delete(car);
        }
    }
}