using System.Threading.Tasks;
using Domains.Repositories;
using Domains.UseCase.UserServices.Exceptions;
using Entities;

namespace Domains.UseCase.UserServices
{
    public class UserDeleteService
    {
        private IUserRepository<User> _repository;
        
        public UserDeleteService(IUserRepository<User> repository)
        {
            this._repository = repository;
        }

        public async Task Execute(int id)
        {
            var user = await this._repository.FindById(id);
            if (user.Id == 0) throw new UserNotFound("Usuário não cadastrado.");
            var userRepository =  await this._repository.Filter( userRepository => userRepository.Id == user.Id );
            if(userRepository == null ) throw new UserNotFound("Usuário não cadastrado.");
            await this._repository.Delete(user);
        }
    }
}