using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Model
{
    public class User : IdentityUser<int>, IAuditable, ITrackable
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual IList<UserRole> UsersRoles { get; set; }
        public DateTime? DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? DeletedBy { get; set; }
    }
}
