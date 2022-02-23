using System;
using System.Linq;
using System.Text.Json;

namespace SQLServerIntro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new CookbookContextFactory();
            using var context = factory.CreateDbContext();

            var porridge = context.Dishes.FirstOrDefault(d => d.Title == "Breakfast Porridge");

            if (porridge == null)
            {
                Console.WriteLine("Breakfast porridge missing. Adding it");

                // Insert record
                porridge = new Dish { Title = "Breakfast Porridge", Notes = "This is sooo good", Stars = 4 };
                context.Dishes.Add(porridge);
                context.SaveChanges();

                Console.WriteLine($"\tAdded ({JsonSerializer.Serialize(porridge)})");
            }

            if (porridge.Stars < 5)
            {
                Console.WriteLine("Adding star to porridge");
                porridge.Stars = 5;
                context.SaveChanges();
            }

            if (context.Ingredients.Any(i => i.Dish == porridge) == false)
            {
                Console.WriteLine("Adding ingredients");

                context.Add(new DishIngredient() { Dish = porridge,
                                                Description = "Havregryn",
                                                Amount = 5m,
                                                UnitOfMeasure = "dl"});

                var ingredients = new DishIngredient[]
                {
                    new DishIngredient() {Dish=porridge, Description="Vatten", Amount=5m, UnitOfMeasure ="dl"},
                    new(){Dish=porridge, Description="Blandade nötter", Amount =1m, UnitOfMeasure="dl"},
                    new(){Dish=porridge,Description="Russin",Amount=3m,UnitOfMeasure="msk"}
                };
                //context.Ingredients.AddRange(ingredients);
                context.AddRange(ingredients);
                context.SaveChanges();
            }

            Console.WriteLine("Removing porridge and all its ingredients");
            foreach (var ingredient in context.Ingredients.Where(i => i.DishId == porridge.Id).ToArray())
            {
                context.Remove(ingredient);
            }
            context.Remove(porridge);
            context.SaveChanges();

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey();
        }
    }
}
