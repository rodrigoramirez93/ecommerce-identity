using Identity.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Identity.Domain.Extensions
{
    public static class IdentityExtensions
    {
        public static List<Claim> GetUserClaims(this IQueryable<User> user, int userId)
        {
            var _user = user
                    .Where(x => x.Id == userId)
                    .Include(y => y.UsersRoles)
                        .ThenInclude(z => z.Role)
                            .ThenInclude(a => a.RoleClaims)
                    .FirstOrDefault();

            if (_user == null) return new List<Claim>();

            var roleClaims = _user.UsersRoles
                                .Select(x => x.Role)
                                .SelectMany(y => y.RoleClaims);

            if (!roleClaims.Any()) return new List<Claim>();

            return roleClaims
                .Select(claims => new Claim(claims.ClaimType, claims.ClaimValue))
                .ToList();
        }
    }
}
