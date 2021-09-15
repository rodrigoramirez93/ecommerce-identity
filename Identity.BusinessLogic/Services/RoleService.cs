using AutoMapper;
using Identity.BusinessLogic.Interfaces;
using Identity.Core.Dto;
using Identity.Core.Helpers;
using Identity.Domain.Extensions;
using Identity.Domain.Model;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Core;
using Shared.Infrastructure.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILoggedUserService _loggedUserService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly LoggedUser _loggedUser;

        public RoleService(
            RoleManager<Role> roleManager,
            IMapper mapper,
            ILoggedUserService loggedUserService,
            IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _loggedUserService = loggedUserService;
            _unitOfWork = unitOfWork;
            _loggedUser = _loggedUserService.GetLoggedUser();
        }

        public async Task<IdentityResult> AddClaimToRoleAsync(int roleId, AccessDto access)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            role.MustExist(nameof(Constants.EntityNames.Role), roleId);

            var claimAlreadyExistInRole = _roleManager.Roles
                .Where(x => x.Id == role.Id)
                .HasClaim(access.Name);

            if (claimAlreadyExistInRole) 
                CommonValidations.AlreadyExistByName("Access", access.Name);

            var claim = new Claim(access.Name, access.Value);
            role.SetAuditInformationUpdate(_loggedUser.Id);

            return await _roleManager.AddClaimAsync(role, claim);
        }

        public async Task<IdentityResult> CreateAsync(CreateRoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            
            role.SetAuditInformationCreate(_loggedUser.Id);
            return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> DeleteAsync(int roleId)
        {
            var role = await _roleManager.Roles.Where(role => role.Id == roleId).FirstOrDefaultAsync();
            role.MustExist(nameof(Constants.EntityNames.Role), roleId);
            role.SetAuditInformationDelete(_loggedUser.Id);
            return await _roleManager.UpdateAsync(role);
        }

        public async Task<List<ReadRoleDto>> GetAsync()
        {
            var roles = await _roleManager.Roles
                .Include(x => x.RoleClaims)
                .ToListAsync();

            var result = roles.Select(role =>
            {
                return new ReadRoleDto()
                {
                    Id = role.Id,
                    Name = role.Name,
                    Claims = _mapper.Map<List<AccessDto>>(role.RoleClaims)
                };
            });

            return result.ToList();
        }

        public async Task<ReadRoleDto> GetByIdAsync(int roleId)
        {
            var role = await _roleManager.Roles
                .Include(r => r.RoleClaims)
                .Where(role => role.Id == roleId)
                .FirstOrDefaultAsync();

            role.MustExist(nameof(Constants.EntityNames.Role), roleId);

            var result = new ReadRoleDto()
            {
                Id = role.Id,
                Name = role.Name,
                Claims = _mapper.Map<List<AccessDto>>(role.RoleClaims).ToList()
            };

            return result;
        }

        public List<AccessDto> GetAccessClaims()
        {
            var claims = _roleManager.Roles.Include(x => x.RoleClaims).SelectMany(y => y.RoleClaims);
            return _mapper.Map<List<AccessDto>>(claims).ToList();
        }

        public async Task<IdentityResult> RemoveClaimFromRoleAsync(int roleId, string claimType)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            role.MustExist(roleId.ToString());
            var claims = await _roleManager.GetClaimsAsync(role);
            var claim = claims.Where(claim => claim.Type == claimType).FirstOrDefault();
            claim.MustExist(nameof(Constants.PropertyNames.Access), nameof(Constants.PropertyValues.Name), claimType);
            role.SetAuditInformationUpdate(_loggedUser.Id);
            return await _roleManager.RemoveClaimAsync(role, claim);
        }

        public async Task<IdentityResult> UpdateAsync(int roleId, UpdateRoleDto roleDto)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(roleId.ToString());
            roleToUpdate.MustExist(nameof(Constants.EntityNames.Role), roleId);
            roleToUpdate.Name = roleDto.Name;
            roleToUpdate.SetAuditInformationUpdate(_loggedUser.Id);
            return await _roleManager.UpdateAsync(roleToUpdate);
        }
    }
}
