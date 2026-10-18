namespace gesApi.src.DTOs {
    public class TicketRes {
        public long Id { get; set; }
        public DateTime BuyDate { get; set; }
        public bool Cleared { get; set; }
        public DateTime ClearedDate { get; set; }
        public int MealId { get; set; }
        public long BuyerId { get; set; }
    }
}