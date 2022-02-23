namespace SQLServerIntro
{
    public class DishIngredient
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string UnitOfMeasure { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public Dish? Dish { get; set; }     // Navigational property
        public int? DishId { get; set; }    // <name>Id gör att detta blir en FK (främmande nyckel)
    }
}