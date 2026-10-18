using System.ComponentModel.DataAnnotations.Schema;

namespace gesApi.src.Data.ModelsEFCore {
    public class Ticket {
        public long Id { get; set; }
        public DateTime BuyDate { get; set; }
        public bool Cleared { get; set; }
        public DateTime? ClearedDate { get; set; }
        public int MealId { get; set; }
        public long BuyerId { get; set; }

        [ForeignKey(nameof(MealId))]
        public Meal Meal { get; set; }
        
        [ForeignKey(nameof(BuyerId))]
        public Buyer Buyer { get; set; }
    }
}