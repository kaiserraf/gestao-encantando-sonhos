using gesApi.src.DTOs;
using gesApi.src.Services.ServicesInterface;
using gesApi.src.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gesApi.src.Controller {
    [ApiController]
    [Route("controller")]
    public class UserAuthController : ControllerBase {

        private readonly IUserAuthService _authService;
        public UserAuthController(IUserAuthService authService) {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] LoginRegisterReq user) {
            try {
                UserRes res = await _authService.RegisterService(user);
                return Created("", res);
            }
            catch (CpfExistsException ce) {
                return StatusCode(StatusCodes.Status400BadRequest, ce.Message);
            }
            catch (DbUpdateException dbe) {
                return StatusCode(StatusCodes.Status500InternalServerError, dbe.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserReq user) {
            try {
                UserRes res = await _authService.LoginService(user);
                return Ok(res);
            }
            catch (IncorrectException ie) {
                return StatusCode(StatusCodes.Status400BadRequest, ie.Message);
            }
            catch (OperationCanceledException ope) {
                return StatusCode(StatusCodes.Status500InternalServerError, ope.Message);
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout() {
            if (!Request.Cookies.TryGetValue("refreshCookie", out string token)) {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
            try {
                bool res = await _authService.Logout(token);
                return Ok(res);
            }
            catch (RefreshTokenNotFindException rtnfe) {
                return StatusCode(StatusCodes.Status401Unauthorized, rtnfe.Message);
            }
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken() {
            if (!Request.Cookies.TryGetValue("refreshCookie", out string token)) {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
            try {
                UserRes res = await _authService.RefreshToken(token);
                return Ok(res);
            }
            catch (Exception e) when (e is RefreshTokenNotFindException or InvalidRefreshTokenException) {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
        }

    }
}