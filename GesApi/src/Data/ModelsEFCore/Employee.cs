using System.ComponentModel.DataAnnotations.Schema;

namespace gesApi.src.Data.ModelsEFCore {
    public class Employee : User {
        public string PasswordHash { get; set; }
        public DateTime RegisterDate { get; set; }
        public int ProfileTypeId { get; set; }

        [ForeignKey(nameof(ProfileTypeId))]
        public ProfileTypes ProfileTypes { get; set; }

        public Employee() {}

        public Employee(string name, string email, string cpf, string passwordHash,
                        int profileTypeId, DateTime registerDate) {
            Name = name;
            Email = email;
            Cpf = cpf;
            PasswordHash = passwordHash;
            ProfileTypeId = profileTypeId;
            RegisterDate = registerDate;
        }

    }
}