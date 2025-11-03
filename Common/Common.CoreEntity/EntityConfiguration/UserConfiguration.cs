using Common.CoreEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.CoreEntity.EntityConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.TableName();
            builder.ConfigurationBaseEntity();
            builder.Property(t => t.Name);
            builder.Property(t => t.Email);
            builder.Property(t => t.Password);
            builder.Property(t => t.Gender);
            builder.Property(t => t.Photo);
            builder.Property(t => t.DateOfBirth);
        }
    }
}
