﻿using Identity.Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Identity.Domain.Model
{
    public class User : IdentityUser<int>, IAuditable
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual IList<UserRole> UsersRoles { get; set; }
        public int? DefaultTenantId { get; set; }
        public Tenant DefaultTenant { get; set; }
        public DateTime? DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public IList<UserTenant> UsersTenants { get; set; }
    }
}
