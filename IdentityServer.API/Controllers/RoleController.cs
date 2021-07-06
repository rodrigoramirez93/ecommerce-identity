using Identity.BusinessLogic.Interfaces;
using Identity.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static Shared.Infrastructure.Core.Constants;

namespace IdentityServer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;

        public RoleController(
            ILogger<RoleController> logger,
            IRoleService roleService
            )
        {
            _logger = logger;
            _roleService = roleService;
        }

        [HttpGet]
        [Authorize(Policy = Claims.CAN_READ_ROLE)]
        public async Task<IActionResult> GetRole()
        {
            return new OkObjectResult(await _roleService.GetAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Policy = Claims.CAN_READ_ROLE)]
        public async Task<IActionResult> GetRoleById(int id)
        {
            return new OkObjectResult(await _roleService.GetByIdAsync(id));
        }

        [HttpGet("Claims")]
        [Authorize(Policy = Claims.CAN_READ_CLAIMS)]
        public IActionResult GetClaims()
        {
            return new OkObjectResult(_roleService.GetAccessClaims());
        }

        [HttpPost]
        [Authorize(Policy = Claims.CAN_CREATE_ROLE)]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto roleDto)
        {
            return new OkObjectResult(await _roleService.CreateAsync(roleDto));
        }

        [HttpPut("{roleId}")]
        [Authorize(Policy = Claims.CAN_UPDATE_ROLE)]
        public async Task<IActionResult> UpdateRole(int roleId, [FromBody] UpdateRoleDto roleDto)
        {
            return new OkObjectResult(await _roleService.UpdateAsync(roleId, roleDto));
        }

        [HttpDelete("{roleId}")]
        [Authorize(Policy = Claims.CAN_DELETE_ROLE)]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            return new OkObjectResult(await _roleService.DeleteAsync(roleId));
        }

        [HttpPost("{roleId}/Access")]
        [Authorize(Policy = Claims.CAN_ADD_CLAIM_TO_ROLE)]
        public async Task<IActionResult> AddClaimToRole(int roleId, [FromBody] AccessDto claimDto)
        {
            return new OkObjectResult(await _roleService.AddClaimToRoleAsync(roleId, claimDto));
        }

        [HttpDelete("{roleId}/Access")]
        [Authorize(Policy = Claims.CAN_DELETE_ROLE)]
        public async Task<IActionResult> Delete(int roleId, string access)
        {
            return new OkObjectResult(await _roleService.RemoveClaimFromRoleAsync(roleId, access));
        }
    }
}
