namespace gesta_encantando_sonhos.src.Models
{
    public class Employee : User
    {
        public string PasswordHash { get; set; }
        public DateTime RegisterDate { get; set; }
        public int ProfileTypeId { get; set; }
        public ProfileTypes ProfileType { get; set; }
    }
}