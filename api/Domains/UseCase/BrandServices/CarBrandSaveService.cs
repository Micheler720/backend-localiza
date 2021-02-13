using System.Threading.Tasks;
using Domains.Repositories;
using Domains.Interfaces;
using Entities;
using Shared.Exceptions;

namespace Domains.UseCase.BrandServices
{
    public class CarBrandSaveService
    {
         
        private IBaseRepository<CarBrand> _repository;
        
        public CarBrandSaveService(IBaseRepository<CarBrand> repository)
        {
            this._repository = repository;
        }

        public async Task Execute (CarBrand register )
        {
            var registerExist = await _repository.Filter( 
                c => c.Name == register.Name && c.Id != register.Id);

            if(registerExist.Count > 0) throw new RegisterExistException("Registro já cadastrado, não é possivel realizar o cadastro.");

            if(register.Id == 0 )
            {
                await this._repository.Add(register);
            }else
            {
                await this._repository.Update(register);                
            }

        }
    }
}