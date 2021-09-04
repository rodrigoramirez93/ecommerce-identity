using Identity.Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Model
{
    public class Role : IdentityRole<int>, IAuditable, ITrackable
    {
        public DateTime? DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public int TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual IList<UserRole> UsersRoles { get; set; }
        public virtual IList<RoleClaim> RoleClaims { get; set; }
    }
}
