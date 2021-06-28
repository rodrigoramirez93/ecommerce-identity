using AutoMapper;
using Identity.Core.Dto;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Mappings
{
    public class TenantProfile : Profile
    {
        public TenantProfile()
        {
            CreateMap<TenantDto, Tenant>().ReverseMap();
        }
    }
}
