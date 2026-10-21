using System.Runtime.InteropServices;
using gesApi.src.Data.DataInterfaces;
using gesApi.src.Data.ModelsEFCore;
using gesApi.src.DTOs;
using gesApi.src.Services.ServicesInterface;
using gesApi.src.Utils.Exceptions;
using gesApi.src.Utils.UtilsInterfaces;
using GesApi.src.Utils.UtilsInterfaces;
using Microsoft.EntityFrameworkCore;

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
            Employee userExists = await _authData.Login(user.Cpf);
            if(userExists is null) throw new IncorrectException("EMAIL OU SENHA INVALIDOS");
            bool validPassword = await _cryptData.VerifyPass(user.Password, userExists.PasswordHash);
            if(validPassword is false) throw new IncorrectException("EMAIL OU SENHA INVALIDOS");

            string acessToken = await _authenticateUser.CreateAcessToken(
                userExists.Id, userExists.ProfileTypeId);

            UserRes response = new UserRes(userExists.Name, userExists.ProfileTypeId, acessToken);
            
            return response;
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
                phone: user.Phone,
                cpf: user.Cpf,
                passwordHash: passwordHash,
                profileTypeId: user.ProfileTypeId,
                registerDate: registerDate
            );

            Employee data = await _authData.Register(u);
            string acessToken = await _authenticateUser.CreateAcessToken(u.Id, u.ProfileTypeId);
            UserRes response = new UserRes(data.Name, data.ProfileTypeId, acessToken);

            return response;
        }
    }
}