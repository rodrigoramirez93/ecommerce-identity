using AutoMapper;
using Identity.Core.Dto;
using Identity.Domain.Model;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Identity.Test
{
    public class AutoMapperTest
    {
        [Fact]
        public void GivenTenantRoleProfile_WhenCheckingMapping_ShouldBeValid()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<TenantRole, TenantRoleDto>()
                    .ForMember(x => x.TenantId, y => y.MapFrom(z => z.Id))
                    .ForMember(x => x.TenantName, y => y.MapFrom(z => z.Name))
                    .ConstructUsing(x => new TenantRoleDto(x.Id, x.Name, x.RoleId, x.RoleName)));

            configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void GivenUserProfileList_WhenCheckingMapping_ShouldBeValid()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<List<TenantRole>, List<TenantRoleDto>>());

            configuration.AssertConfigurationIsValid();
        }
    }
}
