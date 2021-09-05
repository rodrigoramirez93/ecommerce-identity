using Identity.Core.Helpers;
using Identity.Domain.Extensions;
using Identity.Domain.Model;
using Identity.Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Models;
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
        private readonly ILoggedUserService _loggedUserService;
        private readonly LoggedUser _loggedUser;

        public DatabaseContext(ILoggedUserService loggedUserService)
        {
            _loggedUserService = loggedUserService;
            _loggedUser = _loggedUserService.GetLoggedUser();
        }

        public DatabaseContext(DbContextOptions options, ILoggedUserService loggedUserService) : base(options)
        {
            _loggedUserService = loggedUserService;
            _loggedUser = _loggedUserService.GetLoggedUser();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            ApplyQueryFilters(builder);
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

        internal void ApplyQueryFilters(ModelBuilder modelBuilder)
        {
            var clrTypes = modelBuilder.Model.GetEntityTypes().Select(et => et.ClrType).ToList();

            foreach (var type in clrTypes)
            {
                if (typeof(ITrackable).IsAssignableFrom(type))
                    modelBuilder.Entity(type).AddQueryFilter<ITrackable>(e => e.Tenant.HeaderName == _loggedUser.ActiveTenant);
                if (typeof(IAuditable).IsAssignableFrom(type))
                    modelBuilder.Entity(type).AddQueryFilter<IAuditable>(e => e.DateDeleted == null);
            }
        }
    }
}
