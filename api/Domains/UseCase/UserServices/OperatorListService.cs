using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Repositories;
using Entities;
using Entities.Interfaces;
using Entities.Roles;
using ViewModel;

namespace Domains.UseCase.UserServices
{
    public class OperatorListService
    {
        private IUserRepository<User> _repository;
        
        public OperatorListService(IUserRepository<User> repository)
        {
            this._repository = repository;
        }
        public async Task<List<OperatorView>> Execute()
        {
            var users =  await _repository.FindByOperator();
            List<OperatorView> userView = users.Select( user =>                 
                new OperatorView()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Registration = user.Registration,
                        } ).ToList();

            return userView;
            
        }
        
    }
}