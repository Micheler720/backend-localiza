using System.Collections.Generic;
using System.Threading.Tasks;
using Domains.Repositories;
using Domains.UseCase.CategoryServices.Exceptions;
using Entities;

namespace Domains.UseCase.CategoryServices
{
    public class CategoryDeleteService
    {
        private IBaseRepository<CarCategory> _repository;
        
        public CategoryDeleteService(IBaseRepository<CarCategory> repository)
        {
            this._repository = repository;
        }

        public async Task Execute (int id)
        {
            if(id == 0) throw new CategoryNotFoundException("Categoria não encontrado.");
            var category = await this._repository.Filter(c => c.Id == id);
            if(category == null) throw new CategoryNotFoundException("Categoria não encontrado.");
            await _repository.Delete(category[0]);
        }
    }
}