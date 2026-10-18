using System.Runtime.InteropServices;
using gesApi.src.Data.DataInterfaces;
using gesApi.src.DTOs;
using gesApi.src.ModelsEFCore;
using gesApi.src.Services.ServicesInterface;
using gesApi.src.Utils.Exceptions;
using gesApi.src.Utils.UtilsInterfaces;
using GesApi.src.Utils.UtilsInterfaces;

namespace gesApi.src.Services {
    public class UserAuthService : IUserAuthService {

        private readonly IUserAuthData _authData;
        private readonly ICryptData _cryptData;
        private readonly IAuthenticateUser _authenticateUser;

        public UserAuthService(IUserAuthData authData, ICryptData cryptData, IAuthenticateUser authenticateUser) {
            _authData = authData;
            _cryptData = cryptData;
            _authenticateUser = authenticateUser;
        }


        public async Task<UserRes> LoginService(LoginUserReq user) {
            throw new NotImplementedException();
        }

        public async Task<UserRes> Logout() {
            throw new NotImplementedException();
        }

        public async Task<UserRes> RefreshToken() {
            throw new NotImplementedException();
        }

        public async Task<UserRes> RegisterService(LoginRegisterReq user) {
            bool cpfExists = await _authData.VerifyCpf(user.Cpf);
            if (cpfExists) throw new CpfExistsException("O CPF JÁ ESTÁ CADASTRADO");

            DateTime registerDate = DateTime.UtcNow;

            string passwordHash = await _cryptData.EncryptPass(user.Password);

            Employee u = new Employee(
                name: user.Name,
                email: user.Email,
                cpf: user.Cpf,
                passwordHash: passwordHash,
                profileTypeId: user.ProfileTypeId,
                registerDate: registerDate
            );


            try {
                Employee data = await _authData.Register(u);
                string acessToken = await _authenticateUser.CreateAcessToken(u.Id, u.ProfileTypeId);
                UserRes response = new UserRes(data.Name, data.ProfileTypeId, acessToken);
            }
            catch (System.Exception) {

                throw;
            }


            throw new NotImplementedException();
        }
    }
}