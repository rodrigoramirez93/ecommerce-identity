using Identity.BusinessLogic.Interfaces;
using Identity.Core;
using Identity.Core.Dto;
using Identity.Domain.Extensions;
using Identity.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shared.Infrastructure.Core;
using Shared.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.BusinessLogic.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public LoginService(
            UserManager<User> userManager,
            IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<TokenDtoResponse> GetToken(SignInDto signInDto)
        {
            var user = _userManager
                .Users
                    .Include(x => x.UsersRoles)
                        .ThenInclude(y => y.Tenant)
                    .Include(x => x.UsersRoles)
                        .ThenInclude(y => y.Role)
                    .SingleOrDefault(u => u.UserName == signInDto.Email);

            if (user == null)
            {
                return new TokenDtoResponse(null, HttpStatusCode.NotFound);
            }

            var pass = new Decode(signInDto.Password)
                .FromBase64String()
                .Solve();

            var userPasswordIsValid = await _userManager.CheckPasswordAsync(user, pass);

            if (!userPasswordIsValid)
            {
                return new TokenDtoResponse(null, HttpStatusCode.BadRequest);
            }

            var baseClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(Constants.Claims.DefaultTenantId, user.TenantId.ToString())
            };

            var tenantInfo = user.UsersRoles.Select(x => new TenantRoleDto(x.Tenant.Id, x.Tenant.Name, x.Tenant.HeaderName?.ToString() ?? "", x.RoleId, x.Role.Name));
            var userTenantClaim = new Claim(Constants.Claims.Tenant, JsonConvert.SerializeObject(tenantInfo, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));

            var userClaims = _userManager.Users.GetUserClaims(user.Id);
            userClaims.Add(userTenantClaim);

            var claims = baseClaims.Concat(userClaims).ToList();

            var token = _jwtService.GenerateJwt(user, claims);
            return new TokenDtoResponse(token, HttpStatusCode.OK);
        }
    }
}
