using Common.CoreEntity.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Common.CoreEntity.EntityConfiguration;
namespace Common.CoreEntity
{
    public static class EntityBuilderExtensions
    {
        public static void ConfigurationBaseEntity<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id);
        }

        public static void ConfigurationExtendEntity<T>(this EntityTypeBuilder<T> builder) where T : ExtendEntity
        {
            builder.ConfigurationBaseEntity();
            builder.Property(t => t.CreatedById);
            builder.Property(t => t.CreatedTime);
            builder.Property(t => t.ModifiedById);
            builder.Property(t => t.ModifiedTime);
        }

        public static void TableName<T>(this EntityTypeBuilder<T> builder) where T : class
        {
            builder.ToTable(string.Format(Constants.TablePrefix, nameof(T)));
        }

        public static void ApplyCommonEntityConfiguration(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RolePermissionMappingConfiguration());
            builder.ApplyConfiguration(new UserRoleMappingConfiguration());
        }
    }
}
