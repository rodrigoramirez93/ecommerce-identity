using Identity.Core;
using Identity.Core.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Model
{
    public class RoleClaim : IdentityRoleClaim<int>
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
    }
}
