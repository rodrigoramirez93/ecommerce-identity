using Identity.Core.Dto;
using Identity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Identity.BusinessLogic.Interfaces
{
    public interface IJwtService
    {
        TokenDto GenerateJwt(User user, List<Claim> claims);
    }
}
