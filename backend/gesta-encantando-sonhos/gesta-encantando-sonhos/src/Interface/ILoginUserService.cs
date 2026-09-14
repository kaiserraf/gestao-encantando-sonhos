using gesta_encantando_sonhos.src.Models;
using Microsoft.AspNetCore.Mvc;

namespace gesta_encantando_sonhos.src.Interface
{
    public interface ILoginUserService
    {
        public IActionResult RegisterService(Employee newUser);
        public IActionResult LoginService(LoginDto user);
        public IActionResult LogoutService();
        public IActionResult RefreshTokenService();
    }
}