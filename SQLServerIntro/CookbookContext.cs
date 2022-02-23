using Microsoft.EntityFrameworkCore;

namespace SQLServerIntro
{
    public class CookbookContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishIngredient> Ingredients { get; set; }

        public CookbookContext(DbContextOptions<CookbookContext> options) : base(options) { }
    }
}
