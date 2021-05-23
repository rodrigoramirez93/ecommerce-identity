using Identity.Core.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(SignUpDto signUpDto);
        Task<List<UserDto>> GetAsync(SearchUserDto searchUser);
    }
}
