using AutoMapper;
using Identity.Core.Dto;
using Identity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<ReadRoleDto, Role>().ReverseMap();
            CreateMap<CreateRoleDto, Role>();
        }
    }
}
