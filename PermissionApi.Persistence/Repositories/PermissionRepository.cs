using Microsoft.EntityFrameworkCore;
using PermissionApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionApi.Persistence.Repositories
{
    public class PermissionRepository:BaseRepository<Permission>
    {
        public PermissionRepository(PermissionDataContext dbContext):base(dbContext)
        { 
        }

        public override async Task<Permission> GetByIdAsync(int Id)
        {
            return await _dbContext.Permission.Include(c => c.PermissionType).FirstOrDefaultAsync(c => c.Id == Id);
        }
        public override async Task<IReadOnlyList<Permission>> ListAllAsync()
        {
            return await _dbContext.Permission.Include(c=> c.PermissionType).OrderByDescending(c => c.Id).ToListAsync();
        }
    }
}
