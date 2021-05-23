using Identity.BusinessLogic.Interfaces;
using Identity.Core;
using Identity.Core.Dto;
using Identity.Domain.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.BusinessLogic.Services
{
    public class JwtService : IJwtService
    {
        private readonly Appsettings _appsettings;
        public JwtService(IOptionsSnapshot<Appsettings> appsettings)
        {
            _appsettings = appsettings.Value;
        }

        public TokenDto GenerateJwt(User user, List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsettings.JwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_appsettings.JwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _appsettings.JwtSettings.Issuer,
                audience: _appsettings.JwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            var idToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenDto(idToken, expires, new UserDto(user.Id.ToString(), user.Firstname, user.Lastname));
        }
    }
}
