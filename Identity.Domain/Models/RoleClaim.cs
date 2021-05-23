using Microsoft.AspNetCore.Identity;
using static Identity.Core.Constants;

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
