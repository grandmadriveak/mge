using Common.CoreEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.CoreEntity.EntityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.TableName();
            builder.ConfigurationBaseEntity();
            builder.Property(t => t.Name);
            builder.Property(t => t.Description);
        }
    }
}
