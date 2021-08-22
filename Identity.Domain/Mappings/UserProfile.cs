using AutoMapper;
using Identity.Core.Dto;
using Identity.Domain.Model;

namespace Identity.Domain.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignUpDto, User>();
            CreateMap<User, UserDto>()
                .ConstructUsing(x => new UserDto(x.Id.ToString(), x.Firstname, x.Lastname))
                .ForSourceMember(x => x.UsersTenants, y => y.DoNotValidate());
        }
    }
}
