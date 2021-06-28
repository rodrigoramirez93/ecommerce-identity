using AutoMapper;
using Identity.BusinessLogic.Interfaces;
using Identity.Core.Dto;
using Identity.Domain;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.BusinessLogic.Services
{
    public class TenantService : ITenantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TenantService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(TenantDto tenantDto)
        {
            await _unitOfWork.Tenants.Create(_mapper.Map<Tenant>(tenantDto));
            _unitOfWork.Commit();
        }
    }
}
