using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Repositories;
using Domains.UseCase.UserServices.Exceptions;
using Entities;
using Entities.Interfaces;
using Entities.Roles;

namespace Domains.UseCase.UserServices
{
    public class UserSaveService
    {
        private IUserRepository<User> _repository;
        
        public UserSaveService(IUserRepository<User> repository)
        {
            this._repository = repository;
        }
        public async Task Execute(User user)
        {
            if(user.Cpf == null  && user.Registration == null) throw new UserNotDefinid(
                "Usuário não foi definido, não foram enviadas informações de CPF e matricula."
                );

            User userExist;

            if(user.Cpf != null ) 
            {
                user.UserRole = UserRole.Person;
                userExist = await _repository.FindByOperatorRegisterNot(user);
            }
            else
            {
                user.UserRole = UserRole.Operator;  
                userExist = await _repository.FindByPersonRegisterNot(user);
            }

            if(userExist != null) throw new UniqUserRegisterCpf("Usuário já registrado.");

            if(user.Id == 0)
            {
                await this._repository.Add(user);
            }
            else
            {                
                await this._repository.Update(user);
            }
        }
       
    }  
}