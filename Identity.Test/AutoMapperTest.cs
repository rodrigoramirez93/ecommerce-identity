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
        public void GivenUserProfileList_WhenCheckingMapping_ShouldBeValid()
        {
            //var configuration = new MapperConfiguration(cfg =>
            //    cfg.CreateMap<List<TenantRole>, List<TenantRoleDto>>());

            //configuration.AssertConfigurationIsValid();
        }
    }
}
