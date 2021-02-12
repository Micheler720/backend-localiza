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

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository<User> _context;
        private readonly UserSave _userSave;
        private readonly UserList _userList;

        public UserController(ILogger<UserController> logger, ContextEntity context)
        {
            _logger = logger;
            this._context =  new UserRepositoryEntity(context);
            this._userSave = new UserSave(_context);
            this._userList = new UserList(_context);
        }

        [HttpGet]
        [Route("/users")]
        [AllowAnonymous]
        public async Task<List<UserView>> Get ()
        {
            return await this._userList.Execute();
        }

        [HttpPost]
        [Route("/users")]
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
    }
}
