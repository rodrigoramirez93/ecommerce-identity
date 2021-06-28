using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using static Identity.Core.Constants;

namespace Identity.Domain.Model
{
    public class RoleClaim : IdentityRoleClaim<int>, IAuditable
    {
        public string Description
        {
            get
            {
                Claims.All.TryGetValue(ClaimType, out string description);
                return description;
            }
            set { }
        }

        public DateTime? DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public virtual Role Role { get; set; }
    }
}
