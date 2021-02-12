using System.Threading.Tasks;
using Domains.Repositories;
using Domains.UseCase.UserServices.Exceptions;
using Entities;

namespace Domains.UseCase.UserServices
{
    public class DeleteUser
    {
        private IBaseRepository<User> _repository;
        
        public DeleteUser(IBaseRepository<User> repository)
        {
            this._repository = repository;
        }

        public async Task Execute(User user)
        {
            if (user.Id == 0) throw new UserNotFound("Usuário não cadastrado.");
            var userRepository =  await this._repository.Filter( userRepository => userRepository.Id == user.Id );
            if(userRepository == null ) throw new UserNotFound("Usuário não cadastrado.");
            await this._repository.Delete(user);
        }
    }
}