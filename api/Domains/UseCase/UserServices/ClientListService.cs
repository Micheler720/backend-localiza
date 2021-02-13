using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Repositories;
using Entities;
using Entities.Interfaces;
using Entities.Roles;
using ViewModel.Users;

namespace Domains.UseCase.UserServices
{
    public class ClientListService
    {
        private IClientRepository<Client> _repository;
        
        public ClientListService(IClientRepository<Client> repository)
        {
            this._repository = repository;
        }
        public async Task<List<ClientView>> Execute()
        {
            var users =  await _repository.FindByClient();
            List<ClientView> userView = users.Select( user =>                 
                new ClientView()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Birthay = user.Birthay,
                            Cpf = user.Cpf,
                        } ).ToList();

            return userView;
            
        }
        
    }
}