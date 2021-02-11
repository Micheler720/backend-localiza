using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Repositories;
using Entities;
using Entities.Interfaces;
using ViewModel;

namespace Domains.UseCase.UserServices
{
    public class UserList
    {
        private IBaseRepository<User> _repository;
        
        public UserList(IBaseRepository<User> repository)
        {
            this._repository = repository;
        }
        public async Task<List<UserView>> Execute()
        {
            var users =  await _repository.GetAll();
            List<UserView> userView = users.Select( user =>                 
                new UserView()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Registration= user.Registration,
                            Birthay = user.Birthay,
                            Cpf = user.Cpf
                        } ).ToList();

            return userView;
            
        }
        
    }
}