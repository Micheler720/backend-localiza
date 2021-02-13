using System.Threading.Tasks;
using Domains.Repositories;
using Entities;
using Domains.UseCase.CarServices.Exceptions;

namespace Domains.UseCase.CarServices
{
    public class CarSaveService
    {
         
        private ICarRepository<Car> _repository;
        
        public CarSaveService(ICarRepository<Car> repository)
        {
            this._repository = repository;
        }

        public async Task Execute (Car car)
        {
            var carExist = await _repository.FindByIsBoardNotId(car);

            if(carExist != null) throw new CarExistException("Carro já cadastrado, não é possivel realizar o cadastro.");

            if(car.Id != 0 )
            {
                await this._repository.Add(car);
            }else
            {
                await this._repository.Update(car);                
            }

        }
    }
}