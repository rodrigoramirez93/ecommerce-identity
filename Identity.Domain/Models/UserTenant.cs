using Identity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Models
{
    public class UserTenant
    {
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
