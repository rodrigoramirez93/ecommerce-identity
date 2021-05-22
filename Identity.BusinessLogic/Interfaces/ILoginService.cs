using Identity.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.BusinessLogic.Interfaces
{
    public interface ILoginService
    {
        Task<TokenDtoResponse> GetToken(SignInDto signUpDto);
    }
}
