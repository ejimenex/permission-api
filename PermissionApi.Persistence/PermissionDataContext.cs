using Microsoft.EntityFrameworkCore;
using PermissionApi.Domain.Entities;

namespace PermissionApi.Persistence
{
    public class PermissionDataContext : DbContext
    {
        public PermissionDataContext(DbContextOptions<PermissionDataContext> options) : base(options)
        {
        }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PermissionDataContext).Assembly);
        }
    }
}
