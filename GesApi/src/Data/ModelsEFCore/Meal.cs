namespace gesApi.src.Data.ModelsEFCore {
    public class Meal {
        public int Id { get; set; }
        public string MealName { get; set; }
        public string[] Items { get; set; }
        public decimal Price { get; set; }
    }
} 