using AutoMapper;
using Identity.BusinessLogic.Interfaces;
using Identity.Core.Dto;
using Identity.Domain.Extensions;
using Identity.Domain.Filters;
using Identity.Domain.Model;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly ILoggedUserService _loggedUserService;
        private readonly UserManager<User> _userManager;
        private readonly LoggedUser _loggedUser;

        public UserService(
            ILogger<UserService> logger,
            IMapper mapper,
            UserManager<User> userManager,
            ILoggedUserService loggedUserService
            )
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _loggedUserService = loggedUserService;
            _loggedUser = _loggedUserService.GetLoggedUser();
        }

        public async Task<IdentityResult> CreateAsync(SignUpDto signUpDto)
        {
            var user = _mapper.Map<SignUpDto, User>(signUpDto);
            user.SetAuditInformationCreate(_loggedUser.Id);
            return await _userManager.CreateAsync(user, signUpDto.Password);
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
