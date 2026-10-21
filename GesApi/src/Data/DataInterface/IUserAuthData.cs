using gesApi.src.DTOs;
using gesApi.src.Data.ModelsEFCore;

namespace gesApi.src.Data.DataInterfaces {
    public interface IUserAuthData {
        public Task<Employee> Register(Employee user);
        public Task<Employee> Login(string cpf);
        public Task<Employee> Logout();
        public Task<Employee> RefreshToken();
        public Task<bool> VerifyCpf(string cpf);
    }
}