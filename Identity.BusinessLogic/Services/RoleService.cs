using AutoMapper;
using Identity.BusinessLogic.Interfaces;
using Identity.Core;
using Identity.Core.Dto;
using Identity.Core.Helpers;
using Identity.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IContextService _contextService;
        private readonly IMapper _mapper;

        public RoleService(
            RoleManager<Role> roleManager,
            IContextService contextService,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _contextService = contextService;
        }

        public async Task<IdentityResult> AddClaimToRoleAsync(string roleId, AccessDto access)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            role.MustExist(nameof(Constants.EntityNames.Role), roleId);
            var claim = new Claim(access.Name, access.Value);
            return await _roleManager.AddClaimAsync(role, claim);
        }

        public async Task<IdentityResult> CreateAsync(CreateRoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> DeleteAsync(int roleId)
        {
            var role = await _roleManager.Roles.Where(role => role.Id == roleId).FirstOrDefaultAsync();
            role.MustExist(nameof(Constants.EntityNames.Role), roleId);
            return await _roleManager.DeleteAsync(role);
        }

        public async Task<List<ReadRoleDto>> GetAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var claims = new List<RoleClaim>();
            _contextService.Do((context) => claims = context.RoleClaims.ToList());

            var result = roles.Select(role =>
            {
                return new ReadRoleDto()
                {
                    Id = role.Id,
                    Name = role.Name,
                    Claims = _mapper.Map<List<AccessDto>>(claims.Where(claim => claim.RoleId == role.Id).ToList())
                };
            });

            return result.ToList();
        }

        public async Task<ReadRoleDto> GetByIdAsync(int roleId)
        {
            var role = await _roleManager.Roles
                .Where(role => role.Id == roleId)
                .FirstOrDefaultAsync();

            role.MustExist(nameof(Constants.EntityNames.Role), roleId);

            var claims = new List<RoleClaim>();

            _contextService.Do((context) => claims = context.RoleClaims.ToList());

            var result = new ReadRoleDto()
            {
                Id = role.Id,
                Name = role.Name,
                Claims = _mapper.Map<List<AccessDto>>(claims.Where(claim => claim.RoleId == role.Id)).ToList()
            };
            return result;
        }

        public List<AccessDto> GetAccessClaims()
        {
            var claims = new List<RoleClaim>();
            _contextService.Do((context) => claims = context.RoleClaims.ToList());
            return _mapper.Map<List<AccessDto>>(claims).ToList();
        }

        public async Task<IdentityResult> RemoveClaimFromRoleAsync(string roleId, string claimType)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            role.MustExist(roleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            var claim = claims.Where(claim => claim.Type == claimType).FirstOrDefault();
            claim.MustExist(nameof(Constants.PropertyNames.Access), nameof(Constants.PropertyValues.Name), claimType);
            return await _roleManager.RemoveClaimAsync(role, claim);
        }

        public async Task<IdentityResult> UpdateAsync(string roleId, UpdateRoleDto roleDto)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(roleId);
            roleToUpdate.MustExist(nameof(Constants.EntityNames.Role), roleId);
            roleToUpdate.Name = roleDto.Name;
            return await _roleManager.UpdateAsync(roleToUpdate);
        }
    }
}
