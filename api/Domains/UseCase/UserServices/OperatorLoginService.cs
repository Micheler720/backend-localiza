using Domains.Repositories;
using Entities;
using Domains.Interfaces;
using System.Threading.Tasks;
using Domains.UseCase.UserServices.Exceptions;
using ViewModel.Users;

namespace Domains.UseCase.UserServices
{
    public class OperatorLoginService
    {
        private IOperatorRepository<Operator> _repository;
        
        public OperatorLoginService(IOperatorRepository<Operator> repository)
        {
            this._repository = repository;
        }

        public async Task<OperatorJWT> Login(OperatorLogin user, IToken token)
        {
           var loggedUser = await _repository.FindByRegistrationAndPassword(user.Resgistration, user.Password);
           if(loggedUser == null) throw new UserNotFound("Usuário ou senha inválidos.");
           return new OperatorJWT(){
             Id = loggedUser.Id,
             Name = loggedUser.Name,
             Registration = loggedUser.Registration,
             Role = loggedUser.UserRole.ToString(),
             Token = token.TokenGenerateOperator(loggedUser)
           };
        }
    }
}