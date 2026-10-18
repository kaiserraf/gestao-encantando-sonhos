namespace gesApi.src.DTOs {
    public class LoginRegisterReq {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ProfileTypeId { get; set; }
    }
}