using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domains.Repositories;
using Domains.UseCase.UserServices.Exceptions;
using Entities;
using Infra.Database.Implementations.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Domains.UseCase.CarServices;
using Infra.Database.Implementations.EntityFramework.Repositories.CarsRepository;
using ViewModel.Cars;
using Domains.UseCase.CarServices.Exceptions;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarRepository<Car> _context;
        private readonly CarSaveService _save;
        private readonly CarListService _list;
        private readonly CarDeleteService _delete;

        public CarController(ILogger<CarController> logger, ContextEntity context)
        {
            _logger = logger;
            _context =  new CarRepositoryEntity(context);
            _save = new CarSaveService(_context);
            _list = new CarListService(_context);
            _delete = new CarDeleteService(_context);
        }

        [HttpGet]
        [Route("/cars")]
        [AllowAnonymous]
        public async Task<List<Car>> Get ()
        {
            return await this._list.Execute();
        }

        [HttpPost]
        [Route("/cars")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CarSaveView carBody)
        {
            try
            {
                var car = new Car() 
                {  
                    Board = carBody.Board, 
                    HourPrice = carBody.HourPrice, 
                    LuggageCapacity = carBody.LuggageCapacity,              
                    TankCapacity = carBody.TankCapacity,              
                    IdBrand = carBody.IdBrand,              
                    IdCategory = carBody.IdCategory,              
                    IdFuel = carBody.IdFuel,              
                    IdModel = carBody.IdModel             
                };
                await _save.Execute(car);
                return StatusCode(201);
            }
            catch(CarExistException err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }

        [HttpPut]
        [Route("/cars")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody]CarSaveView carBody)
        {
            try
            {
                 
                var car = new Car() 
                {  
                    Id = carBody.Id,
                    Board = carBody.Board, 
                    HourPrice = carBody.HourPrice, 
                    LuggageCapacity = carBody.LuggageCapacity,              
                    TankCapacity = carBody.TankCapacity,              
                    IdBrand = carBody.IdBrand,              
                    IdCategory = carBody.IdCategory,              
                    IdFuel = carBody.IdFuel,              
                    IdModel = carBody.IdModel             
                };
                await _save.Execute(car);
                return StatusCode(204);
            }
            catch(CarExistException err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }

        [HttpDelete]
        [Route("/cars/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _delete.Execute(id);
                return StatusCode(204);
            }
            catch(CarNotFoundException err)
            {
                return StatusCode(404, new {
                    Message = err.Message
                });
            }
        }     

        
    }
}
