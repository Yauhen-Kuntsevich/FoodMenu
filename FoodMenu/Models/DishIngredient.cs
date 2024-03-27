namespace FoodMenu.Models;

public class DishIngredient
{
    public int DishId { get; set; }
    public Dish Dish { get; set; } = null!;
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; } = null!;
}