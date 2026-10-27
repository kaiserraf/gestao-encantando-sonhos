using gesApi.src.Data.ModelsEFCore;

namespace gesApi.src.DTOs {
    public class TicketRes {
        public long Id { get; set; }
        public DateTime BuyDate { get; set; }
        public bool Cleared { get; set; }
        public DateTime? ClearedDate { get; set; }
        public int MealId { get; set; }
        public long BuyerId { get; set; }

        public TicketRes() {}
        public TicketRes(long id, DateTime buyDate, bool cleared,
                         DateTime? clearedDate, int mealId, long buyerId) {
            Id = id;
            BuyDate = buyDate;
            Cleared = cleared;
            ClearedDate = clearedDate;
            MealId = mealId;
            BuyerId = buyerId;
        }

        public TicketRes(DateTime buyDate, bool cleared, int mealId, long buyerId) {
            BuyDate = buyDate;
            Cleared = cleared;
            MealId = mealId;
            BuyerId = buyerId;
        }
    }
}