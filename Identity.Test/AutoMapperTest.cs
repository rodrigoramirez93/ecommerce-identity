using Xunit;
using Identity.BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using Identity.Domain;
using AutoMapper;
using System;
using Identity.BusinessLogic.Interfaces;
using Identity.Domain.Mappings;
using Infrastructure.Services;
using System.Threading.Tasks;
using Identity.Domain.Models;
using Identity.Core.Dto;

namespace Identity.Test
{
    [Trait("RunOnBuild", "true")]
    public class TenantServiceTest
    {
        private readonly DatabaseContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly int _invalidId = 1;
        public TenantServiceTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
              .Options;

            _context = new DatabaseContext(options, new LoggedUserService());

            var _mapperConfig = new MapperConfiguration(cfg => cfg.AddMaps(typeof(TenantProfile).Assembly));
            _mapper = new Mapper(_mapperConfig);
            _unitOfWork = new UnitOfWork(_context);
            
        }
        
        [Fact]
        public async Task GivenProductService_WhenAddingValidProduct_ShouldAddWithoutErrors()
        {
            //arrange
            var service = new TenantService(_mapper, _unitOfWork);
            var tenantDto = new TenantDto(){ Name = "test" }; 

            await service.Create(tenantDto);
            
            Assert.True(0==0);
        }
    }
}
