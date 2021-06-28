using Identity.Domain.Extensions;
using Identity.Domain.Model;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Identity.Domain
{
    public class DatabaseContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Tenant> Tenants { get; set; }

        enum UserEnum
        {
            System = 1
        }

        public override int SaveChanges()
        {
            var changeSet = ChangeTracker.Entries<IAuditable>();

            if (changeSet != null)
            {
                var entitiesAdded = changeSet.Where(changes => changes.State == EntityState.Added);
                var entitiesUpdated = changeSet.Where(changes => changes.State == EntityState.Modified);
                var entitiesDeleted = changeSet.Where(changes => changes.State == EntityState.Deleted);

                if (entitiesAdded.Any()) entitiesAdded.SetAuditInformationCreate((int)UserEnum.System);
                if (entitiesUpdated.Any()) entitiesUpdated.SetAuditInformationUpdate((int)UserEnum.System);
                if (entitiesDeleted.Any()) entitiesDeleted.SetAuditInformationDelete((int)UserEnum.System);
            }

            return base.SaveChanges();
        }
    }
}
