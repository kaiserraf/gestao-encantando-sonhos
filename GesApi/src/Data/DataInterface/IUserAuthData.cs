using gesApi.src.DTOs;
using gesApi.src.Data.ModelsEFCore;

namespace gesApi.src.Data.DataInterfaces {
    public interface IUserAuthData {
        public Task<Employee> Register(Employee user);
        public Task<Employee> Login(string cpf);
        public Task<RefreshTokens> FindRefreshTokenAndEmployee(string token);
        public Task<bool> DeleteRefreshToken(string token);
        public Task<bool> CreateRefreshToken(RefreshTokens refreshTokens);
        public Task<bool> VerifyCpf(string cpf);
    }
}