using System.ComponentModel.DataAnnotations.Schema;

namespace gesApi.src.Data.ModelsEFCore {
    public class RefreshTokens {
        public int Id { get; set; }
        public string Token { get; set; }
        public long EmployeeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiresAt { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public RefreshTokens(string token, long employeeId, DateTime createdDate, DateTime expiresAt) {
            Token = token;
            EmployeeId = employeeId;
            CreatedDate = createdDate;
            ExpiresAt = expiresAt;
        }
    }
}