using Identity.BusinessLogic.Interfaces;
using Identity.Core.Dto;
using Identity.Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static Identity.Core.Constants;

namespace IdentityServer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Policy = Claims.CAN_READ_USERS)]
        public async Task<IActionResult> Get(string id, string firstName, string lastName)
        {
            return new OkObjectResult(
                await _userService.GetAsync(
                    new SearchUserDto(id, firstName, lastName)));
        }

        [HttpPost]
        [Authorize(Policy = Claims.CAN_CREATE_USERS)]
        public async Task<IActionResult> Post(SignUpDto signUpDto)
        {
            var response = await _userService.CreateAsync(signUpDto);
            if (!response.Succeeded)
                return Problem(detail: response.Errors.ToProblemDescription(), statusCode: 400);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = Claims.CAN_UPDATE_USERS)]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = Claims.CAN_DELETE_USERS)]
        public void Delete(int id)
        {
        }
    }
}
