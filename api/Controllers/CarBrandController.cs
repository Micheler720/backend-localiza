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
using Domains.UseCase.CategoryServices.Exceptions;
using Domains.UseCase.BrandServices;
using Shared.Exceptions;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarBrandController : ControllerBase
    {
        private readonly ILogger<CarBrandController> _logger;
        private readonly BaseEntityRepository<CarBrand> _context;
        private readonly CarBrandSaveService _save;
        private readonly CarBrandDeleteService _delete;
        private readonly CarBrandListService _list;

        public CarBrandController(ILogger<CarBrandController> logger, ContextEntity context)
        {
            _logger = logger;
            _context = new BaseEntityRepository<CarBrand>(context);
            _save = new CarBrandSaveService(_context);
            _delete = new CarBrandDeleteService(_context);
            _list = new CarBrandListService(_context);
        }

        [HttpGet]
        [Route("/cars/brands")]
        [AllowAnonymous]
        public async Task<List<RegisterView>> Get ()
        {
            return await this._list.Execute();
        }

        [HttpPost]
        [Route("/cars/brands")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] RegisterView register)
        {
            try
            {
                var brand = new CarBrand()
                {
                    Name = register.Name
                };
                await _save.Execute(brand);
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
        [Route("/cars/brands")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] RegisterView register)
        {
            try
            {
                var brand = new CarBrand()
                {
                    Id = register.Id, 
                    Name = register.Name
                };
                await _save.Execute(brand);
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
        [Route("/cars/brands/{id}")]
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
