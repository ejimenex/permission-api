using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionApi.Domain.Entities;

namespace PermissionApi.Persistence.Configuration
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.HasMany(e => e.Permission).WithOne(c => c.PermissionType);

        }

    }
}
