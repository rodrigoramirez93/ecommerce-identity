using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Shared.Infrastructure.Core.Constants;

namespace Identity.Domain.DbConfigs
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable(Tables.Tenant);
        }
    }

    public class UserTenantConfiguration : IEntityTypeConfiguration<UserTenant>
    {
        public void Configure(EntityTypeBuilder<UserTenant> builder)
        {
            builder.ToTable(Tables.UserTenant);

            builder.HasKey(x => new { x.TenantId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.UsersTenants)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Tenant)
                .WithMany(x => x.UsersTenants)
                .HasForeignKey(x => x.TenantId);
        }
    }
}
