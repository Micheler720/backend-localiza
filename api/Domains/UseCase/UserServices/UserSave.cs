using System.Linq;
using System.Threading.Tasks;
using Domains.Repositories;
using Domains.UseCase.UserServices.Exceptions;
using Entities;
using Entities.Interfaces;
using Entities.Roles;

namespace Domains.UseCase.UserServices
{
    public class UserSave
    {
        private IBaseRepository<User> _repository;
        
        public UserSave(IBaseRepository<User> repository)
        {
            this._repository = repository;
        }
        public async Task Execute(User user)
        {
            if(user.Cpf != null  && user.Registration != null) throw new UserNotDefinid(
                "Usuário não foi definido, foram enviadas informações de CPF e matricula."
                );


            if(user.Cpf != null ) 
            {
                user.UserRole = UserRole.Person;
            }
            else
            {
                user.UserRole = UserRole.Operator;                
            }
            
            if(user.Id == 0)
            {
                var userExist = await _repository.Filter(
                    userRepository => user.Registration == userRepository.Registration
                );

                if(userExist.Count > 0) throw new UniqUserRegisterCpf("User already registered");

                await this._repository.Add(user); 
                return;         

            }
            else
            {
                var userExist = await _repository.Filter(
                    userRepository => user.Registration == userRepository.Registration
                                    && user.Id != userRepository.Id
                );

                if(userExist.Count > 0) throw new UniqUserRegisterCpf("User already registered");

                await this._repository.Add(user);
            }
        }
       
    }  
}