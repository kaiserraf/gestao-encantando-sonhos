using gesta_encantando_sonhos.src.Models;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller para login/logout para todos os usuarios
/// </summary>

namespace gesta_encantando_sonhos.src.Controllers.LoginUser.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LoginUserController : ControllerBase
    {
        // injeção de dependencia LoginUserController

        [HttpPost]
        public IActionResult Register([FromBody] Employee newUser)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto user)
        {
            throw new NotImplementedException();
        }

        public IActionResult Logout()
        {
            throw new NotImplementedException();
        }
        public IActionResult RefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}