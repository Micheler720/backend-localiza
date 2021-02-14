using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Infra.Database.Implementations.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Domains.UseCase.CarServices;
using Domains.UseCase.CategoryServices;
using Infra.Database.Implementations.EntityFramework.Repositories;
using ViewModel.Shared;
using Domains.UseCase.CategoryServices.Exceptions;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarCategoryController : ControllerBase
    {
        private readonly ILogger<CarCategoryController> _logger;
        private readonly BaseEntityRepository<CarCategory> _context;
        private readonly CategorySaveService _save;
        private readonly CategoryDeleteService _delete;
        private readonly CategoryListService _list;

        public CarCategoryController(ILogger<CarCategoryController> logger, ContextEntity context)
        {
            _logger = logger;
            _context = new BaseEntityRepository<CarCategory>(context);
            _save = new CategorySaveService(_context);
            _delete = new CategoryDeleteService(_context);
            _list = new CategoryListService(_context);
        }

        [HttpGet]
        [Route("/cars/categories")]
        [AllowAnonymous]
        public async Task<List<RegisterView>> Get ()
        {
            return await this._list.Execute();
        }

        [HttpPost]
        [Route("/cars/categories")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] RegisterView register)
        {
            try
            {
                var category = new CarCategory()
                {
                    Name = register.Name
                };
                await _save.Execute(category);
                return StatusCode(201);
            }
            catch(CategoryExistException err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }

        [HttpPut]
        [Route("/cars/categories")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] RegisterView register)
        {
            try
            {
                var category = new CarCategory()
                {
                    Id = register.Id, 
                    Name = register.Name
                };
                await _save.Execute(category);
                return StatusCode(204);
            }
            catch(CategoryExistException err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }

        [HttpDelete]
        [Route("/cars/categories/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete( int id)
        {
            try
            {
                await _delete.Execute(id);
                return StatusCode(204);
            }
            catch(CategoryNotFoundException err)
            {
                return StatusCode(404, new {
                    Message = err.Message
                });
            }
        }

        

        
    }
}
