using System.Collections.Generic;
using System.Threading.Tasks;
using Domains.Repositories;
using Entities;

namespace Domains.UseCase.AppointmentService
{
    public class ChekListListService
    {
        private IChecklistRepository<CheckList> _repository;

        public ChekListListService(IChecklistRepository<CheckList> repository)
        {
            _repository = repository;
        }

        public async Task<List<CheckList>> Execute()
        {
            return await _repository.GetAll();
        }
    }
}