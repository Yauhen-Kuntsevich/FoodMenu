namespace FoodMenu.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public List<DishIngredient> DishIngredients { get; set; } = null!;
}