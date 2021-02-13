using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Repositories;
using Entities;

namespace Infra.Database.Fake
{
    public class FakeUserRepository : FakeBaseRepository<User>, IUserRepository<User>
    {
        public async Task<User> FindByOperatorRegisterNot(User user)
        {
            await Task.Delay(2000);
            return this._data
                        .Where(data => user.Id != data.Id && data.Registration == user.Registration)
                        .FirstOrDefault();
        }
        public async Task<User> FindByPersonRegisterNot(User user)
        {
            await Task.Delay(2000);
            return this._data
                        .Where(data => user.Id != data.Id && data.Cpf == user.Cpf)
                        .FirstOrDefault();
                        
        }

        public async Task<User> FindById(int id)
        {
            await Task.Delay(2000);
            return this._data
                        .Where(data => data.Id == id )
                        .FirstOrDefault();
        }

        public async Task<User> FindByCpfAndPassword(string cpf, string password)
        {
            await Task.Delay(2000);
            return this._data
                        .Where(data => data.Cpf == cpf && data.Password == password )
                        .FirstOrDefault();
        }

        public async Task<User> FindByRegistrationAndPassword(string registration, string password)
        {
            await Task.Delay(2000);
            return this._data
                        .Where(data => data.Registration == registration && data.Password == password )
                        .FirstOrDefault();
        }
    }
}