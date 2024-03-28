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
    
    public async Task<IActionResult> Index()
    {
        return View(await _context.Dishes.ToListAsync());
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