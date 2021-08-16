using AutoMapper;
using Identity.Core.Dto;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Mappings
{
    public class TenantRoleProfile : Profile
    {
        public TenantRoleProfile()
        {
            CreateMap<TenantRole, TenantRoleDto>()
                .ForMember(x => x.TenantId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.TenantName, y => y.MapFrom(z => z.Name))
                .ConstructUsing(x => new TenantRoleDto(x.Id, x.Name, x.RoleId, x.RoleName));

            CreateMap<List<TenantRole>, List<TenantRoleDto>>();
        }
    }
}
