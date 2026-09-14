namespace gesta_encantando_sonhos.src.Models
{
    public class Ticket
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
        public DateTime BuyDate { get; set; }
        public bool Cleared { get; set; }
        public DateTime? ClearedDate { get; set; }
        public int MealId { get; set; }
        public Meals Meals { get; set; }
    }
}