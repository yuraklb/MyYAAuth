using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyYAAuth.Auth.Api.Models;
using MyYAAuth.Auth.Common;
using MyYAAuth.Auth.Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace MyYAAuth.Auth.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        
        private readonly IOptions<AuthOptions> _authOptions;
        private readonly IAccountsService accountsService;

        public AuthController(ILogger<AuthController> logger, IOptions<AuthOptions> authOptions, IAccountsService accountsService)
        {
            this.accountsService = accountsService;
            _authOptions = authOptions;
            _logger = logger;
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Login request)
        {
            var user = AuthenticateUser(request.Email, request.Password);

            if (user != null)
            {
                var token = JwtGeneratorsService.GenerateJWT(_authOptions.Value, user);
                //var token2 = JwtGeneratorsService.GenerateJWT2(_authOptions.Value, user);

                return Ok(
                    new
                    {
                        access_token = token
                    }
                );
            }

            return Unauthorized();
        }

        private Account AuthenticateUser(string email, string password)
        {
            return accountsService.GetAccount(email, password); 
        }
    }
}