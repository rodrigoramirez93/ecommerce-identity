using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Extensions
{
    public static class Entity
    {
        public static void SetAuditInformationUpdate(this IEnumerable<IAuditable> entities, int updatedBy)
        {
            foreach (var entity in entities)
            {
                entity.UpdatedBy = updatedBy;
                entity.DateUpdated = DateTime.UtcNow;
            }
        }

        public static void SetAuditInformationUpdate(this IAuditable entity, int updatedBy)
        {
            entity.UpdatedBy = updatedBy;
            entity.DateUpdated = DateTime.UtcNow;
        }

        public static void SetAuditInformationCreate(this IEnumerable<IAuditable> entities, int createdBy)
        {
            foreach (var entity in entities)
            {
                entity.CreatedBy = createdBy;
                entity.DateCreated = DateTime.UtcNow;
            }
        }

        public static void SetAuditInformationCreate(this IAuditable entity, int createdBy)
        {
            entity.CreatedBy = createdBy;
            entity.DateCreated = DateTime.UtcNow;
        }

        public static void SetAuditInformationDelete(this IEnumerable<IAuditable> entities, int deletedBy)
        {
            foreach(var entity in entities)
            {
                entity.DeletedBy = deletedBy;
                entity.DateDeleted = DateTime.UtcNow;
            }
        }

        public static void SetAuditInformationDelete(this IAuditable entity, int deletedBy)
        {
            entity.DeletedBy = deletedBy;
            entity.DateDeleted = DateTime.UtcNow;
        }
    }
}
