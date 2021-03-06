using Identity.Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace Identity.Domain.Model
{
    public class UserRole : IdentityUserRole<int>, IAuditable
    {
        public DateTime? DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public int TenantId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
