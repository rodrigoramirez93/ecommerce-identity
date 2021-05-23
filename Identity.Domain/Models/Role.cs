using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Model
{
    public class Role : IdentityRole<int>
    {
        public virtual IList<UserRole> UsersRoles { get; set; }
    }
}
