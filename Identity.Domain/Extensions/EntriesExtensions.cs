using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace Identity.Domain.Extensions
{
    public static class EntriesExtensions
    {
        public static void SetAuditInformationUpdate(this IEnumerable<EntityEntry<IAuditable>> entityEntries, int modifiedBy)
        {
            foreach (var entry in entityEntries)
            {
                entry.Entity.DateUpdated = DateTime.UtcNow;
                entry.Entity.UpdatedBy = modifiedBy;
            }
        }

        public static void SetAuditInformationCreate(this IEnumerable<EntityEntry<IAuditable>> entityEntries, int createdBy)
        {
            foreach (var entry in entityEntries)
            {
                entry.Entity.DateCreated = DateTime.UtcNow;
                entry.Entity.CreatedBy = createdBy;
            }
        }

        public static void SetAuditInformationDelete(this IEnumerable<EntityEntry<IAuditable>> entityEntries, int deletedBy)
        {
            foreach (var entry in entityEntries)
            {
                entry.Entity.DateDeleted = DateTime.UtcNow;
                entry.Entity.DeletedBy = deletedBy;
            }
        }
    }
}
