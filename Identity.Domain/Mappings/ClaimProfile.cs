using AutoMapper;
using Identity.Core.Dto;
using Identity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Identity.Domain.Mappings
{
    public class ClaimProfile : Profile
    {
        public ClaimProfile()
        {
            CreateMap<AccessDto, Claim>()
                .ForMember(x => x.Type, y => y.MapFrom(map => map.Name))
                .ForMember(x => x.Value, y => y.MapFrom(map => map.Value))
                .ReverseMap();

            CreateMap<RoleClaim, AccessDto>()
                .ForMember(x => x.Name, y => y.MapFrom(map => map.ClaimType))
                .ForMember(x => x.Value, y => y.MapFrom(map => map.ClaimValue));
        }
    }
}
