using Identity.BusinessLogic.Interfaces;
using Identity.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace IdentityServer.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ILoginService _loginService;

        public AuthController(
            ILogger<AuthController> logger,
            ILoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody]SignInDto signInDto)
        {
            var response = await _loginService.GetToken(signInDto);

            return response.HttpStatusCode switch
            {
                HttpStatusCode.BadRequest => BadRequest("Email or password incorrect."),
                HttpStatusCode.NotFound => NotFound("Username not found"),
                HttpStatusCode.OK => Ok(response.Token),
                _ => BadRequest("Something went wrong"),
            };
        }
    }
}
