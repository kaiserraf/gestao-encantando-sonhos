using System.ComponentModel.DataAnnotations.Schema;

namespace gesApi.src.Data.ModelsEFCore {
    public class Buyer {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public long EmployeeId { get; set; }

        public long? LeadBuyerId { get; set; }
        

        [ForeignKey(nameof(LeadBuyerId))]
        public Buyer LeadBuyer { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}