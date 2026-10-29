namespace gesApi.src.DTOs {
    public class UserRes {
        public long Id { get; set; }
        public string Name { get; set; }
        public int ProfileTypeId { get; set; }
        public string AcessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserRes(string name, int profileTypeId, string acessToken, string refreshToken) {
            Name = name;
            ProfileTypeId = profileTypeId;
            AcessToken = acessToken;
            RefreshToken = refreshToken;
        }
    }
}