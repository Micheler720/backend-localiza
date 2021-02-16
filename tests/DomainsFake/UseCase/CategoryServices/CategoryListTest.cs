using System.Threading.Tasks;
using Domains.UseCase.CarServices;
using Domains.UseCase.ModelServices;
using Entities;
using Infra.Database.Fake;
using NUnit.Framework;

namespace DomainsFake.UseCase.CategoryServices
{
    public class CategoryListTest
    {
        
        private CategoryListService _service;
        private FakeBaseRepository<CarCategory> _repository;

        [SetUp]
        public void Setup()
        {
            this._repository = new  FakeBaseRepository<CarCategory>();
            this._service = new CategoryListService(_repository);
        }

        [Test]
        public async Task ListModelCar ()
        {
            
            await this._repository.Add( new CarCategory(){
                Id = 123,             
            });

            var modelCarList = await this._service.Execute();

            Assert.AreEqual(modelCarList[0].Id, 123);
        }
    }
}