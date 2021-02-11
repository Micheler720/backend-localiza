using System.Linq;
using System.Threading.Tasks;
using Domains.Repositories;
using Domains.UseCase.UserServices.Exceptions;
using Entities;

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

            if(user.Id == 0)
            {
                var userExist = await _repository.Filter(
                    userRepository => userRepository.Cpf  == user.Cpf || 
                                    user.Registration == userRepository.Registration
                );

                if(userExist.Count > 0) throw new UniqUserRegisterCpf("User already registered");

                await this._repository.Add(user); 
                return;         

            }
            else
            {
                var userExist = await _repository.Filter(
                    userRepository => userRepository.Cpf  == user.Cpf || 
                                    user.Registration == userRepository.Registration
                                    && user.Id != userRepository.Id
                );

                if(userExist.Count > 0) throw new UniqUserRegisterCpf("User already registered");

                await this._repository.Add(user);
            }
        }
    }  
}