using Ecommerce.Core.Dto;
using Ecommerce.Core.ServicesContract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(Ecommerce.Core.Dto.RegisterRequest registerRequest) {

            if (registerRequest == null)
                return BadRequest("invlaid input");
            AuthenticationResponse? response = await userService.Register(registerRequest);

            if (response == null || response.sucess == false)
                return BadRequest(response);
            return Ok(response);

        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(Ecommerce.Core.Dto.LoginRequest loginRequest)
        {

            if (loginRequest.Email == null || loginRequest.Password == null)
                return BadRequest("invlaid input");
            AuthenticationResponse? response = await userService.Login(loginRequest);

            if (response == null || response.sucess == false)
                return Unauthorized(response);
            return Ok(response);

        }
    }
}
