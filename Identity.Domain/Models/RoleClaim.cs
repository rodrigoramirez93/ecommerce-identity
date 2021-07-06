using Microsoft.AspNetCore.Identity;
using static Shared.Infrastructure.Core.Constants;

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

        public virtual Role Role { get; set; }
    }
}
