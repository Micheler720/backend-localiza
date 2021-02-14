using System;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domains.Repositories;

namespace Infra.Database.Implementations.EntityFramework.Repositories.AppointmentRepository
{
    public class ChecklistRepositoryEntity  : BaseEntityRepository<CheckList>, IChecklistRepository<CheckList>
    {
        public ChecklistRepositoryEntity(ContextEntity context) : base(context)
        {
            
        }

        public async Task<CheckList> FindById(int id)
        {
            var query = from a in _context.CheckLists
                where  id == a.Id
                select a;
            return await query.FirstOrDefaultAsync<CheckList>() as CheckList;
        }
    }
}