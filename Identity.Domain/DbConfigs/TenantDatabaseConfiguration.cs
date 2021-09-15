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

            builder.HasMany(x => x.Users)
                .WithOne(x => x.DefaultTenant)
                .HasForeignKey(x => x.DefaultTenantId);
        }
    }
}
