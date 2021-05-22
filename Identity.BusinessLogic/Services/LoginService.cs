using Identity.BusinessLogic.Interfaces;
using Identity.Core;
using Identity.Core.Dto;
using Identity.Domain.Model;
using Microsoft.AspNetCore.Identity;
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
        private readonly RoleManager<Role> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly IContextService _contextService;

        public LoginService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IJwtService jwtService,
            IContextService contextService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
            _contextService = contextService;
        }

        public async Task<TokenDtoResponse> GetToken(SignInDto signInDto)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == signInDto.Email);

            if (user is null)
            {
                return new TokenDtoResponse(null, HttpStatusCode.NotFound);
            }

            var pass = new Decrypt(signInDto.Password)
                .FromBase64String()
                .Solve();

            var userPasswordIsValid = await _userManager.CheckPasswordAsync(user, pass);

            if (!userPasswordIsValid)
            {
                return new TokenDtoResponse(null, HttpStatusCode.BadRequest);
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var rolesNames = await _userManager.GetRolesAsync(user);
            var rolesIds = _roleManager.Roles.Where(role => rolesNames.Contains(role.Name)).Select(x => x.Id).ToList();
            var roleClaims = new List<RoleClaim>();

            _contextService.Do((context) =>
            {
                roleClaims = context.RoleClaims.Where(x => rolesIds.Contains(x.RoleId)).ToList();
            });

            var userClaims = roleClaims.Select(claim => new Claim(claim.ClaimType, claim.ClaimValue)).ToList();

            claims.AddRange(userClaims);

            var token = _jwtService.GenerateJwt(user, claims);
            return new TokenDtoResponse(token, HttpStatusCode.OK);
        }
    }
}
