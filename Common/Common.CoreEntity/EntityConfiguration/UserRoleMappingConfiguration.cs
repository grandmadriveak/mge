using Common.CoreEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.CoreEntity.EntityConfiguration
{
    public class UserRoleMappingConfiguration : IEntityTypeConfiguration<UserRoleMapping>
    {
        public void Configure(EntityTypeBuilder<UserRoleMapping> builder)
        {
            builder.TableName();
            builder.HasKey(t => new { t.UserId, t.RoleId });
            builder.Property(t => t.UserId);
            builder.Property(t => t.RoleId);
        }
    }
}
