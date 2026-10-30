using gesApi.src.DTOs;

namespace gesApi.src.Services.ServicesInterface {
    public interface IUserAuthService {
        public Task<UserRes> RegisterService(LoginRegisterReq user);
        public Task<UserRes> LoginService(LoginUserReq user);
        public Task<bool> Logout(string token);
        public Task<UserRes> RefreshToken(string token);
    }
}