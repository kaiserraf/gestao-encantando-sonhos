using gesApi.src.DTOs;
using gesApi.src.ModelsEFCore;

namespace gesApi.src.Data.DataInterfaces {
    public interface IUserAuthData {
        public Task<Employee> Register(Employee user);
        public Task<Employee> Login(LoginUserReq user);
        public Task<Employee> Logout();
        public Task<Employee> RefreshToken();
        public Task<bool> VerifyCpf(string cpf);
    }
}