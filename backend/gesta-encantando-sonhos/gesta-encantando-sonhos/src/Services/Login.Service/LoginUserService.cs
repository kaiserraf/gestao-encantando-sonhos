using gesta_encantando_sonhos.src.Interface;
using gesta_encantando_sonhos.src.Models;
using Microsoft.AspNetCore.Mvc;

namespace gesta_encantando_sonhos.src.Services.Login.Service
{
    public class LoginUserService : ILoginUserService
    {
        public IActionResult RegisterService(Employee newUser)
        {
            throw new NotImplementedException();
        }
        public IActionResult LoginService(LoginDto user)
        {
            throw new NotImplementedException();
        }

        public IActionResult LogoutService()
        {
            throw new NotImplementedException();
        }

        public IActionResult RefreshTokenService()
        {
            throw new NotImplementedException();
        }
    }
}