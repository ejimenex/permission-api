using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionApi.Domain.Entities;

namespace PermissionApi.Persistence.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasOne(e => e.PermissionType).WithMany(c => c.Permission);

        }

    }
}
