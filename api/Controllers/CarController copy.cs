using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Repositories;
using Domains.UseCase.UserServices;
using Domains.UseCase.UserServices.Exceptions;
using Entities;
using Infra.Database.Implementations.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infra.Database.Implementations.EntityFramework.Repositories;
using Microsoft.AspNetCore.Authorization;
using ViewModel;
using Infra.Database.Implementations.EntityFramework.Repositories.UsersRespository;
using Infra.Authentication;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly IUserRepository<User> _context;
        private readonly UserSaveService _userSave;
        private readonly UserDeleteService _userDelete;
        private readonly OperatorLoginService _clientLogin;

        public CarController(ILogger<CarController> logger, ContextEntity context)
        {
            _logger = logger;
            this._context =  new UserRepositoryEntity(context);
            this._userSave = new UserSaveService(_context);
            this._clientLogin = new OperatorLoginService(_context);
            this._userDelete = new UserDeleteService(_context);
        }

        [HttpGet]
        [Route("/cars")]
        [AllowAnonymous]
        public async Task Get ()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("/cars")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                await _userSave.Execute(user);
                return StatusCode(201);
            }
            catch(UniqUserRegisterCpf err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }

        [HttpPut]
        [Route("/cars")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            try
            {
                await _userSave.Execute(user);
                return StatusCode(204);
            }
            catch(UniqUserRegisterCpf err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }
        [HttpDelete]
        [Route("/cars/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            try
            {
                await _userDelete.Execute(id);
                return StatusCode(204);
            }
            catch(UserNotFound err)
            {
                return StatusCode(404, new {
                    Message = err.Message
                });
            }
        }

        [HttpPost]
        [Route("/cars/login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody]OperatorLogin user)
        {  
            try
            {
                return StatusCode(200, await _clientLogin.Login(user, new Authentication()));
            }
            catch(UserNotFound err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }

        
    }
}
