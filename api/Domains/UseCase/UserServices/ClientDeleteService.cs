using System.Threading.Tasks;
using Domains.Repositories;
using Domains.UseCase.UserServices.Exceptions;
using Entities;
using Entities.Interfaces;

namespace Domains.UseCase.UserServices
{
    public class ClientDeleteService
    {
        private IClientRepository<Client> _repository;
        
        public ClientDeleteService(IClientRepository<Client> repository)
        {
            this._repository = repository;
        }

        public async Task Execute(int id)
        {
            var user = await this._repository.FindById(id);
            if (id == 0) throw new UserNotFound("Usuário não cadastrado.");
            var userRepository =  await this._repository.FindById(id);
            if(userRepository == null ) throw new UserNotFound("Usuário não cadastrado.");
            await this._repository.Delete(userRepository);
        }
    }
}