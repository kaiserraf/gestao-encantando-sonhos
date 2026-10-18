using System.ComponentModel.DataAnnotations.Schema;

namespace gesApi.src.Data.ModelsEFCore {
    public class Buyer : User {
        public long EmployeeId { get; set; }

        public long? LeadBuyerId { get; set; }
        

        [ForeignKey(nameof(LeadBuyerId))]
        public Buyer LeadBuyer { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}