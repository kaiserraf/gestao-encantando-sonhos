using gesApi.src.Config;
using gesApi.src.DTOs;
using gesApi.src.Data.ModelsEFCore;
using Microsoft.EntityFrameworkCore;

namespace gesApi.src.Data.DataInterfaces {
    public class UserAuthData : IUserAuthData {

        private readonly GesContext _context;
        public UserAuthData(GesContext context) {
            _context = context;
        }

        public async Task<Employee> Register(Employee user) {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Employee> Login(string cpf) {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Cpf == cpf);
        }

        public async Task<Employee> Logout() {
            throw new NotImplementedException();
        }

        public async Task<Employee> RefreshToken() {
            throw new NotImplementedException();
        }

        public async Task<bool> RefreshTokenCreate(RefreshTokens refreshTokens) {
            await _context.RefreshTokens.AddAsync(refreshTokens);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> VerifyCpf(string cpf) {
            return await _context.Employees.AnyAsync(e => e.Cpf == cpf);
        }

    }
}