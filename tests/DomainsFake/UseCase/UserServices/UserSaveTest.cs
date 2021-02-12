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
    public class UserSaveTest
    {        
        private UserSave _service;
        private FakeUserRepository _repository;

        [SetUp]
        public void Setup()
        {
            this._repository = new FakeUserRepository();
            this._service = new UserSave(_repository);
        }

        
        [Test]
        public async Task AddUserSucess()
        {
            var user = new User()
            {
                Id = 0,
                Name = "user-test",
                Birthay = new DateTime(2020,05,01),
                Registration= "test-registration"
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
            var user = new User()
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
        public async Task TestUserOperator()
        {
            var user = new User()
            {
                Id = 123,
                Name = "user-test",
                Registration = "test-registration"
            };

            await this._repository.Add(user);

            await this._service.Execute(user);
            var userRegister = await this._repository.GetAll();

            Assert.AreEqual(userRegister[0].Registration, "test-registration");
            Assert.AreEqual(userRegister[0].UserRole, UserRole.Operator);
        }

        [Test]
        public async Task NotRegisterUserAlreadyExists()
        {
            var user = new User()
            {
                Id = 0,
                Name = "user-test",
                Registration = "test-registration"
            };

            var userCpf = new User()
            {
                Id = 0,
                Name = "user-test",
                Cpf = "test-cpf"
            };

            await this._repository.Add(
                new User()
                    {
                        Id = 123,
                        Name = "user-test",
                        Registration = "test-registration"
                    }
            );

            Exception exception = null;

            try{
                await this._service.Execute(user);
                await this._service.Execute(userCpf);

            }catch(UniqUserRegisterCpf ex)
            {
                exception = ex;
            }

            Assert.AreNotEqual(exception, null);
        }

        [Test]
        public async Task NotRegisterUserAlreadyRegisterAndCpf()
        {
            var user = new User()
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