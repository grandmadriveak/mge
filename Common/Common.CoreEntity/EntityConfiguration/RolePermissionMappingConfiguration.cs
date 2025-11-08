using Common.CoreEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.CoreEntity.EntityConfiguration
{
    public class RolePermissionMappingConfiguration : IEntityTypeConfiguration<RolePermissionMapping>
    {
        public void Configure(EntityTypeBuilder<RolePermissionMapping> builder)
        {
            builder.TableName();
            builder.HasKey(t => new { t.RoleId, t.Permission });
            builder.Property(t => t.RoleId);
            builder.Property(t => t.Permission);
        }
    }
}
