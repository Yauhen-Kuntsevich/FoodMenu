using Microsoft.AspNetCore.Mvc;
using FoodMenu.Data;
using FoodMenu.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodMenu.Controllers;

public class Menu : Controller
{
    private readonly FoodMenuContext _context;

    public Menu(FoodMenuContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index(string searchString)
    {
        var dishes = from d in _context.Dishes select d;
        
        if (!string.IsNullOrEmpty(searchString))
        {
            searchString = searchString.ToLower();
            dishes = dishes.Where(d => d.Name.ToLower().Contains(searchString));
            return View(await dishes.ToListAsync());
        }
        
        return View(await dishes.ToListAsync());
    }

    public async Task<IActionResult> Details(int id)
    {
        var dish = await _context.Dishes
            .Include(d => d.DishIngredients)
            .ThenInclude(di => di.Ingredient)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (dish == null)
        {
            NotFound();
        }
        return View(dish);
    }
}