using Identity.BusinessLogic.Interfaces;
using Identity.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    [AllowAnonymous]
    public class TenantController : Controller
    {
        private readonly ITenantService _tenantService;
        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpPost]
        //[Authorize(Policy = Claims.CAN_READ_ROLE)]
        public async Task<IActionResult> CreateTenant(TenantDto tenantDto)
        {
            await _tenantService.Create(tenantDto);
            return Ok();
        }
    }
}
