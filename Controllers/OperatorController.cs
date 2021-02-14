using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domains.UseCase.UserServices;
using Domains.UseCase.UserServices.Exceptions;
using Entities;
using Infra.Database.Implementations.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using ViewModel.Users;
using Infra.Authentication;
using Domains.Repositories;
using Infra.Database.Implementations.EntityFramework.Repositories.UsersRespository;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperatorController : ControllerBase
    {
        private readonly ILogger<OperatorController> _logger;
        private readonly IOperatorRepository<Operator> _context;
        private readonly OperatorSaveService _userSave;
        private readonly OperatorListService _userList;
        private readonly OperatorDeleteService _userDelete;
        private readonly OperatorLoginService _clientLogin;

        public OperatorController(ILogger<OperatorController> logger, ContextEntity context)
        {
            _logger = logger;
            this._context =  new OperatorRepositoryEntity(context);
            this._userSave = new OperatorSaveService(_context);
            this._userList = new OperatorListService(_context);
            this._clientLogin = new OperatorLoginService(_context);
            this._userDelete = new OperatorDeleteService(_context);
        }

        [HttpGet]
        [Route("/operators")]
        [AllowAnonymous]
        public async Task<List<OperatorView>> Get ()
        {
            return await this._userList.Execute();
        }

        [HttpPost]
        [Route("/operators")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] OperatorSaveView userBody)
        {
            try
            {
                var user = new Operator() 
                {  
                    Registration = userBody.Registration, 
                    Name = userBody.Name, 
                    Password = userBody.Password                 
                };
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
        [Route("/operators")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody]OperatorSaveView userBody)
        {
            try
            {
                var user = new Operator() 
                {  
                    Id = userBody.Id,
                    Registration = userBody.Registration, 
                    Name = userBody.Name, 
                    Password = userBody.Password                 
                };
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
        [Route("/operators/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
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
        [Route("/operators/login")]
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
