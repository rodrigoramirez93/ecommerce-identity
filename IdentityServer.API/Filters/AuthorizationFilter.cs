using Identity.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;
using static Identity.Core.Constants;

namespace IdentityServer.API.Filters
{
    public class AuthorizationFilter: IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool hasAllowAnonymous = 
                context
                    .ActionDescriptor
                    .EndpointMetadata
                        .Any(attribute => attribute.GetType() == typeof(AllowAnonymousAttribute));

            if (hasAllowAnonymous)
                return;

            var _loggedUserService = context.HttpContext.RequestServices.GetService(typeof(ILoggedUserService)) as ILoggedUserService;
            if (_loggedUserService == null)
                return;

            var claims = ((ClaimsIdentity)context.HttpContext.User.Identity).Claims;
            var tenantClaim = claims.Where(x => x.Type == Claims.Tenant);
            var idClaim = claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

            _loggedUserService.SetUserId(idClaim);
            _loggedUserService.SetEmail(context.HttpContext.User.Identity.Name);
            _loggedUserService.SetClaims(claims.Except(tenantClaim));
            _loggedUserService.SetTenants(tenantClaim);
        }
    }
}
