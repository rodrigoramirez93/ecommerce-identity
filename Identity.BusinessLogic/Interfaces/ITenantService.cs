using Identity.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.BusinessLogic.Interfaces
{
    public interface ITenantService
    {
        Task Create(TenantDto tenantDto);
    }
}
