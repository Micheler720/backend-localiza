using System.Threading.Tasks;
using Domains.Repositories;
using Domains.UseCase.UserServices.Exceptions;
using Entities;
using Entities.Interfaces;
using Entities.Roles;

namespace Domains.UseCase.UserServices
{
    public class ClientSaveService
    {
        private IClientRepository<Client> _repository;
        
        public ClientSaveService(IClientRepository<Client> repository)
        {
            this._repository = repository;
        }
        public async Task Execute(Client client = null)
        {
            if(client.Cpf == null ) throw new UserNotDefinid(
                "CPF de cliente não foi definido."
                );

            IUser userExist;

                client.UserRole = UserRole.Person;
                userExist = await _repository.FindByPersonRegisterNot(client);
                if(userExist != null) throw new UniqUserRegisterCpf("Usuário já registrado.");

                if(client.Id == 0)
                {
                    await this._repository.Add(client);
                    return;
                }              
                await this._repository.Update(client);
            
        }
       
    }  
}