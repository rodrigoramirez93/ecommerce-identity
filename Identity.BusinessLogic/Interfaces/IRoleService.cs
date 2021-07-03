using Identity.Core.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.BusinessLogic.Interfaces
{
    public interface IRoleService
    {
        Task<List<ReadRoleDto>> GetAsync();
        Task<ReadRoleDto> GetByIdAsync(int roleId);
        Task<IdentityResult> UpdateAsync(int roleId, UpdateRoleDto roleDto);
        Task<IdentityResult> CreateAsync(CreateRoleDto roleDto);
        Task<IdentityResult> AddClaimToRoleAsync(int roleId, AccessDto claimDto);
        Task<IdentityResult> RemoveClaimFromRoleAsync(int roleId, string claimType);
        Task<IdentityResult> DeleteAsync(int roleId);
        List<AccessDto> GetAccessClaims();
    }
}
