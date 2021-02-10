using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Infra.Database.Implementations.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ContextEntity _context;

        public UserController(ILogger<UserController> logger, ContextEntity context)
        {
            _logger = logger;
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            throw new NotImplementedException();
        }
    }
}
