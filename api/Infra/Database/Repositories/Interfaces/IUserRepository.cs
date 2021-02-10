using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Infra.Database.Repositories;

namespace Infra.Database.Repositories.Interfaces
{
    public interface IUserRepository<User> : IBaseRepository<User> where User : class
    {

    }
}