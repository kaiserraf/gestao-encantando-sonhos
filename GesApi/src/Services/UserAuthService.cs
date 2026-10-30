using System.Security.Cryptography;
using gesApi.src.Data.DataInterfaces;
using gesApi.src.Data.ModelsEFCore;
using gesApi.src.DTOs;
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
            Employee userExists = await _authData.Login(user.Cpf);
            if(userExists is null) throw new IncorrectException("CPF OU SENHA INVALIDOS");
            bool validPassword = await _cryptData.VerifyPass(user.Password, userExists.PasswordHash);
            if(validPassword is false) throw new IncorrectException("CPF OU SENHA INVALIDOS");

            string acessToken = await _authenticateUser.CreateAccessToken(
                userExists.Id, userExists.ProfileTypeId, 1);
            string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

            RefreshTokens refreshObj = new RefreshTokens(
                token: refreshToken,
                employeeId: userExists.Id,
                createdDate: DateTime.UtcNow,
                expiresAt: DateTime.UtcNow.AddDays(3)
            );

            await _authData.CreateRefreshToken(refreshObj);

            UserRes loginResponse = new UserRes(userExists.Name, userExists.ProfileTypeId, acessToken, refreshToken);
            
            return loginResponse;
        }

        public async Task<bool> Logout(string token) {
            return await _authData.DeleteRefreshToken(token);
        }

        public async Task<UserRes> RefreshToken(string token) {
            RefreshTokens oldRefreshToken = await _authData.FindRefreshTokenAndEmployee(token);
            
            if(oldRefreshToken is null) throw new RefreshTokenNotFindException();

            bool deleted = await _authData.DeleteRefreshToken(oldRefreshToken.Token);
            if(!deleted) throw new RefreshTokenNotFindException();

            if(oldRefreshToken.ExpiresAt < DateTime.UtcNow) throw new InvalidRefreshTokenException();

            string newAcessToken = await _authenticateUser.CreateAccessToken(
                oldRefreshToken.Employee.Id, oldRefreshToken.Employee.ProfileTypeId, 1);
            string newRefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

            RefreshTokens refreshObj = new RefreshTokens(
                token: newRefreshToken,
                employeeId: oldRefreshToken.Employee.Id,
                createdDate: DateTime.UtcNow,
                expiresAt: DateTime.UtcNow.AddDays(3)
            );
            
            await _authData.CreateRefreshToken(refreshObj);

            return new UserRes(
                oldRefreshToken.Employee.Name, 
                oldRefreshToken.Employee.ProfileTypeId,
                newAcessToken,
                newRefreshToken
            );
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

            UserRes registerResponse = new UserRes(data.Name, data.ProfileTypeId);

            return registerResponse;
        }
    }
}