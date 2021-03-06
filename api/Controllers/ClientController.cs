﻿using System;
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
using ViewModel.Users;
using Infra.Database.Implementations.EntityFramework.Repositories.UsersRespository;
using Infra.Authentication;
using Entities.Roles;
using Entities.Interfaces;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientRepository<Client> _context;
        private readonly ClientSaveService _userSave;
        private readonly ClientListService _userList;
        private readonly ClientDeleteService _userDelete;
        private readonly ClientLoginService _clientLogin;

        public ClientController(ILogger<ClientController> logger, ContextEntity context)
        {
            _logger = logger;
            _context =  new ClientRepositoryEntity(context);
            _userSave = new ClientSaveService(_context);
            _userList = new ClientListService(_context);
            _clientLogin = new ClientLoginService(_context);
            _userDelete = new ClientDeleteService(_context);
        }


        [HttpGet]
        [Route("/clients")]
        [AllowAnonymous]
        public async Task<List<ClientView>> Get ()
        {
            return await this._userList.Execute();
        }

        [HttpPost]
        [Route("/clients")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] ClientSaveView userBody)
        {
            try
            {
                var user = new Client() 
                {  
                    Cpf = userBody.Cpf, 
                    Name = userBody.Name, 
                    Password = userBody.Password, 
                    Birthay = userBody.Birthay                  
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
        [Route("/clients")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] ClientSaveView userBody)
        {
            try
            {                
                var user = new Client() 
                {  
                    Id = userBody.Id,
                    Cpf = userBody.Cpf, 
                    Name = userBody.Name, 
                    Password = userBody.Password, 
                    Birthay = userBody.Birthay                  
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
        [Route("/clients/{id}")]
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
        [Route("/clients/login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody]ClientLogin user)
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
