using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Infra.Database.Implementations.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Infra.Database.Implementations.EntityFramework.Repositories;
using ViewModel.Shared;
using Domains.UseCase.ModelServices;
using Shared.Exceptions;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarModelController : ControllerBase
    {
        private readonly ILogger<CarModelController> _logger;
        private readonly BaseEntityRepository<CarModel> _context;
        private readonly CarModelSaveService _save;
        private readonly CarModelDeleteService _delete;
        private readonly CarModelListService _list;

        public CarModelController(ILogger<CarModelController> logger, ContextEntity context)
        {
            _logger = logger;
            _context = new BaseEntityRepository<CarModel>(context);
            _save = new CarModelSaveService(_context);
            _delete = new CarModelDeleteService(_context);
            _list = new CarModelListService(_context);
        }

        [HttpGet]
        [Route("/cars/models")]
        [AllowAnonymous]
        public async Task<List<RegisterView>> Get ()
        {
            return await this._list.Execute();
        }

        [HttpPost]
        [Route("/cars/models")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] RegisterView register)
        {
            try
            {
                var category = new CarModel()
                {
                    Name = register.Name
                };
                await _save.Execute(category);
                return StatusCode(201);
            }
            catch(RegisterExistException err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }

        [HttpPut]
        [Route("/cars/models")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] RegisterView register)
        {
            try
            {
                var category = new CarModel()
                {
                    Id = register.Id, 
                    Name = register.Name
                };
                await _save.Execute(category);
                return StatusCode(204);
            }
            catch(RegisterExistException err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }

        [HttpDelete]
        [Route("/cars/models/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete( int id)
        {
            try
            {
                await _delete.Execute(id);
                return StatusCode(204);
            }
            catch(NotFoundRegisterException err)
            {
                return StatusCode(404, new {
                    Message = err.Message
                });
            }
        }

        

        
    }
}
