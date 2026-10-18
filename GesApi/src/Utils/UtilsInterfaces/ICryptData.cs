namespace gesApi.src.Utils.UtilsInterfaces {
    public interface ICryptData {
        public Task<string> EncryptPass(string password);
        public Task<bool> VerifyPass(string password, string hash);
    }
}