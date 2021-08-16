using Identity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Models
{
    public class UserTenant
    {
        public int TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
