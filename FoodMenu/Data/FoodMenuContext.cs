using Microsoft.EntityFrameworkCore;
using FoodMenu.Models;

namespace FoodMenu.Data;

public class FoodMenuContext : DbContext
{
    public FoodMenuContext(DbContextOptions<FoodMenuContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DishIngredient>().HasKey(di => new { di.DishId, di.IngredientId });
        modelBuilder.Entity<DishIngredient>().HasOne(di => di.Dish).WithMany(d => d.DishIngredients)
            .HasForeignKey(di => di.DishId);
        modelBuilder.Entity<DishIngredient>().HasOne(di => di.Ingredient).WithMany(i => i.DishIngredients)
            .HasForeignKey(di => di.IngredientId);

        modelBuilder.Entity<Dish>().HasData(
            new Dish { Id = 1, Name = "Marheritta", Price = 7.50, ImageUrl = "https://de.ooni.com/cdn/shop/articles/Margherita-9920.jpg?crop=center&height=800&v=1644589966&width=800" }
        );
        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { Id = 1, Name = "Tomato Cause"},
            new Ingredient { Id = 2, Name = "Mozzarella"}
        );
        modelBuilder.Entity<DishIngredient>().HasData(
            new DishIngredient { DishId = 1, IngredientId = 1 },
            new DishIngredient { DishId = 1, IngredientId = 2 }
        );
        
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<DishIngredient> DishIngredients { get; set; }
}