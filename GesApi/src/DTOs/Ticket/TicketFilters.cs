using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesApi.src.DTOs.Ticket {
    public class TicketFilters {
        public bool? Cleared { get; set; }
        public int? MealId { get; set; }
        public long? BuyerId { get; set; }
        public DateTime? BuyDateStart { get; set; } // data da compra maior ou igual que
        public DateTime? BuyDateEnd { get; set; } // data da compra menor ou igual que
    }
}