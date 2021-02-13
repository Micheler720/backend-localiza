using System.Collections.Generic;
using System.Threading.Tasks;
using Domains.Interfaces;
using Domains.Repositories;
using Entities;
using Shared.Exceptions;

namespace Domains.UseCase.BrandServices
{
    public class CarBrandDeleteService
    {
        private IBaseRepository<CarBrand> _repository;
        
        public CarBrandDeleteService(IBaseRepository<CarBrand> repository)
        {
            this._repository = repository;
        }

        public async Task Execute (int id)
        {
            if(id == 0) throw new NotFoundRegisterException("Modelo não encontrado.");
            var register = await this._repository.Filter(c => c.Id == id);
            if(register == null) throw new NotFoundRegisterException("Modelo não encontrado.");
            await _repository.Delete(register[0]);
        }
    }
}