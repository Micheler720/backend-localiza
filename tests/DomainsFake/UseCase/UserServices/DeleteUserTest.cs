using NUnit.Framework;
using Domains.UseCase.UserServices;
using Infra.Database.Fake;
using Entities;
using System;
using System.Threading.Tasks;
using Domains.UseCase.UserServices.Exceptions;

namespace DomainsFake.UseCase.UserServices
{
    public class DeleteUserTest
    {
        private DeleteUser _service;
        private FakeBaseRepository<User> _repository;

        [SetUp]
        public void Setup()
        {
            this._repository = new FakeBaseRepository<User>();
            this._service = new DeleteUser(_repository);

        }
        [Test]
        public async Task DeleteUserSucess()
        {
            var user = new User()
            {
                Id = 123,
                Name = "user-test",
                Birthay = new DateTime(2020,05,01),
                Registration = "123"
            };
            await this._repository.Add(user);
            Exception exception = null;
            try
            {
              await this._service.Execute(user);
            }
            catch (UserNotFound ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception, null);
        }

        [Test]
        public async Task NotDeleteUserIdZero()
        {
            var user = new User()
            {
                Id = 0,
                Name = "user-test",
                Birthay = new DateTime(2020,05,01),
                Registration = "123"
            };
            Exception exception = null;
            try
            {
              await this._service.Execute(user);
            }
            catch (UserNotFound ex)
            {
                exception = ex;
            }

            Assert.AreNotEqual(exception, null);
        }
        public async Task NotDeleteUserRegisterNot()
        {
            var user = new User()
            {
                Id = 123,
                Name = "user-test",
                Birthay = new DateTime(2020,05,01),
                Registration = "123"
            };
            Exception exception = null;
            try
            {
              await this._service.Execute(user);
            }
            catch (UserNotFound ex)
            {
                exception = ex;
            }

            Assert.AreNotEqual(exception, null);
        }
    }
}