using System;
using System.Threading.Tasks;
using Domains.UseCase.UserServices;
using Domains.UseCase.UserServices.Exceptions;
using Entities;
using Entities.Roles;
using Infra.Database.Fake;
using NUnit.Framework;

namespace DomainsFake.UseCase.UserServices
{
    public class ClientSaveTest
    {        
        private ClientSaveService _service;
        private FakeClientRepository _repository;

        [SetUp]
        public void Setup()
        {
            this._repository = new FakeClientRepository();
            this._service = new ClientSaveService(_repository);
        }

        
        [Test]
        public async Task AddUserSucess()
        {
            var user = new Client()
            {
                Id = 0,
                Name = "user-test",
                Birthay = new DateTime(2020,05,01),
                Cpf= "test-registration"
            };
            Exception exception = null;
            try
            {
              await this._service.Execute(user);
            }
            catch (UserNotDefinid ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception, null);
        }
        
        [Test]
        public async Task TestUserPerson()
        {
            var user = new Client()
            {
                Id = 123,
                Name = "user-test",
                Birthay = new DateTime(2020,05,01),
                Cpf = "13122785609"
            };

            await this._repository.Add(user);

            await this._service.Execute(user);
            var userRegister = await this._repository.GetAll();

            Assert.AreEqual(userRegister[0].Cpf, "13122785609");
            Assert.AreEqual(userRegister[0].UserRole, UserRole.Person);
        }        

       

        [Test]
        public async Task NotRegisterUserAlreadyCpf()
        {
            var user = new Client()
            {
                Id = 0,
                Name = "user-test",
            };

            Exception exception = null;

            try{
                await this._service.Execute(user);

            }catch(UserNotDefinid ex)
            {
                exception = ex;
            }

            Assert.AreNotEqual(exception, null);
        }
    }
}