using GamePickerWeb.Data;
using GamePickerWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamePickerWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        List<Category> objCategoryList = _db.Categories.ToList();
        
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category item)
    {
        if (ModelState.IsValid)
        {
            _db.Categories.Add(item);
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        return View(item);
    }
}