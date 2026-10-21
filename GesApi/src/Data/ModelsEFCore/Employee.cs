using System.ComponentModel.DataAnnotations.Schema;

namespace gesApi.src.Data.ModelsEFCore {
    public class Employee {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegisterDate { get; set; }
        public int ProfileTypeId { get; set; }

        [ForeignKey(nameof(ProfileTypeId))]
        public ProfileTypes ProfileTypes { get; set; }

        public Employee() {}

        public Employee(string name, string phone, string cpf, string passwordHash,
                        int profileTypeId, DateTime registerDate) {
            Name = name;
            Phone = phone;
            Cpf = cpf;
            PasswordHash = passwordHash;
            ProfileTypeId = profileTypeId;
            RegisterDate = registerDate;
        }

    }
}