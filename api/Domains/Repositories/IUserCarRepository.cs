using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domains.Repositories
{
    public interface IUserCarRepository<User> : IBaseRepository<User> where User : class
    {
        
    }
}