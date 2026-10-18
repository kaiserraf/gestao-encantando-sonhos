using gesApi.src.DTOs;
using gesApi.src.Services.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace gesApi.src.Controller {
    [ApiController]
    [Route("controller")]
    public class UserAuthController : ControllerBase{

        private readonly IUserAuthService _authService;
        public UserAuthController(IUserAuthService authService) {
            _authService = authService;
        }


        // register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] LoginRegisterReq user) {
            try
            {
                UserRes res = await _authService.RegisterService(user);
                return Ok(res);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        // login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserReq user) {
            throw new NotImplementedException();
        }

        // logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout() {
            throw new NotImplementedException();
        }

        // refresh token
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken() {
            throw new NotImplementedException();
        }

    }
}