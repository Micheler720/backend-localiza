using System.Threading.Tasks;
using Domains.Repositories;
using Entities;
using Shared.Exceptions;

namespace Domains.UseCase.AppointmentService
{
    public class CheckListDeleteService
    {
        private IChecklistRepository<CheckList> _repository;

        public CheckListDeleteService(IChecklistRepository<CheckList> repository)
        {
            _repository = repository;
        }

        public async Task Execute(int id)
        {
            if(id == 0 ) throw new NotFoundRegisterException("CheckList não Encontrado.");
            var checklist = await _repository.FindById(id);
            if(checklist == null ) throw new NotFoundRegisterException("CheckList não Encontrado.");
            await _repository.Delete(checklist);

        }
    }
}