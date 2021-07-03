using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Identity.BusinessLogic.Interfaces
{
    public interface ILoggedUserService
    {
        public void SetEmail(string email);

        public void SetClaims(IEnumerable<Claim> claims);

        public void SetTenants(IEnumerable<Claim> tenantIds);

        public void SetUserId(Claim tenantIds);

        public LoggedUser GetLoggedUser();
    }
}
