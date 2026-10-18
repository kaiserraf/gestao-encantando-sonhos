using gesApi.src.Utils.UtilsInterfaces;

namespace gesApi.src.Utils {
    public class CryptData : ICryptData {
        public async Task<string> EncryptPass(string password) {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return passwordHash;
        }

        public async Task<bool> VerifyPass(string password, string hash) {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}