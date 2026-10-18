using gesApi.src.DTOs;

namespace gesApi.src.Services.ServicesInterface {
    public interface IUserAuthService {
        public Task<UserRes> RegisterService(LoginRegisterReq user);
        public Task<UserRes> LoginService(LoginUserReq user);
        public Task<UserRes> Logout();
        public Task<UserRes> RefreshToken();
    }
}