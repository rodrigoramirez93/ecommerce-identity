using AutoMapper;
using Identity.BusinessLogic.Interfaces;
using Identity.Core.Dto;
using Identity.Domain.Extensions;
using Identity.Domain.Filters;
using Identity.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(
            ILogger<UserService> logger,
            IMapper mapper,
            UserManager<User> userManager
            )
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(SignUpDto signUpDto)
        {
            var user = _mapper.Map<SignUpDto, User>(signUpDto);
            user.SetAuditInformationCreate(1);
            return await _userManager.CreateAsync(user, signUpDto.Password);
        }

        public async Task<List<UserDto>> GetAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<List<UserDto>> GetAsync(SearchUserDto searchUser)
        {
            var users = new UserFilter(_userManager.Users)
                .HasId(searchUser.Id)
                .HasFirstName(searchUser.FirstName)
                .HasLastName(searchUser.LastName)
                .GetQuery();

            return _mapper.Map<List<UserDto>>(users.ToList());
        }
    }
}
