using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Domains.Repositories
{
    public interface IUserRepository<User> : IBaseRepository<User> where User : class
    {

    }
}