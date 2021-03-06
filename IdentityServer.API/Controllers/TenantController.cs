using Identity.BusinessLogic.Interfaces;
using Identity.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Shared.Infrastructure.Core.Constants;

namespace IdentityServer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TenantController : Controller
    {
        private readonly ITenantService _tenantService;
        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpPost]
        [Authorize(Policy = Claims.CAN_CREATE_TENANT)]
        public async Task<IActionResult> CreateTenant(TenantDto tenantDto)
        {
            await _tenantService.Create(tenantDto);
            return Ok();
        }
    }
}
