using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        internal static void AddQueryFilter<T>(this EntityTypeBuilder entityTypeBuilder, Expression<Func<T, bool>> expression)
        {
            var parameterType = Expression.Parameter(entityTypeBuilder.Metadata.ClrType);
            var expressionFilter = ReplacingExpressionVisitor.Replace(
                expression.Parameters.Single(), parameterType, expression.Body);

            var currentQueryFilter = entityTypeBuilder.Metadata.GetQueryFilter();
            if (currentQueryFilter != null)
            {
                var currentExpressionFilter = ReplacingExpressionVisitor.Replace(
                    currentQueryFilter.Parameters.Single(), parameterType, currentQueryFilter.Body);
                expressionFilter = Expression.AndAlso(currentExpressionFilter, expressionFilter);
            }

            var lambdaExpression = Expression.Lambda(expressionFilter, parameterType);
            entityTypeBuilder.HasQueryFilter(lambdaExpression);
        }
    }
}
