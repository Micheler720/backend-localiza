using Domains.Repositories;
using Entities;
using Domains.Interfaces;
using System.Threading.Tasks;
using Domains.UseCase.UserServices.Exceptions;
using ViewModel;

namespace Domains.UseCase.UserServices
{
    public class ClientLoginService
    {
        private IUserRepository<User> _repository;
        
        public ClientLoginService(IUserRepository<User> repository)
        {
            this._repository = repository;
        }

        public async Task<ClientJWT> Login(ClientLogin user, IToken token)
        {
           var loggedUser = await _repository.FindByCpfAndPassword(user.Cpf, user.Password);
           if(loggedUser == null) throw new UserNotFound("Usuário ou senha inválidos.");
           return new ClientJWT(){
             Id = loggedUser.Id,
             Name = loggedUser.Name,
             Cpf = loggedUser.Cpf,
             Role = loggedUser.UserRole.ToString(),
             Token = token.TokenGenerate(loggedUser)
           };
        }
    }
}