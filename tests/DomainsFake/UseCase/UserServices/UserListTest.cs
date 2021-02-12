using System.Threading.Tasks;
using Domains.UseCase.UserServices;
using Entities;
using Infra.Database.Fake;
using NUnit.Framework;

namespace DomainsFake.UseCase.UserServices
{
    public class UserListTest
    {
        private UserList _service;
        private FakeUserRepository _repository;

        [SetUp]
        public void Setup()
        {
            this._repository = new FakeUserRepository();
            this._service = new UserList(_repository);
        }

        [Test]
        public async Task ListUserView()
        {
            await this._repository.Add( new User(){
                Id = 123,
                Name = "test-user",
                Registration="123154", 
                Password = "123456",               
            });

            var userView = await this._service.Execute();

            Assert.AreEqual(userView[0].Name, "test-user");
            Assert.AreEqual(userView[0].Registration, "123154");
        }
    }
}