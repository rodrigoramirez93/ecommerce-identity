using AutoMapper;
using Identity.Core.Dto;
using Identity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignUpDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));

            CreateMap<User, UserDto>();
        }
    }
}
