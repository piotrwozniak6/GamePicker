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
            TempData["success"] = "Category created successfully";
            
            return RedirectToAction("Index");
        }

        return View();
    }
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Category? categoryDb = _db.Categories.Find(id);

        if (categoryDb == null)
        {
            return NotFound();
        }
        
        return View(categoryDb);
    }
    [HttpPost]
    public IActionResult Edit(Category item)
    {
        if (ModelState.IsValid)
        {
            _db.Categories.Update(item);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            
            return RedirectToAction("Index");
        }

        return View();
    }
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Category? categoryDb = _db.Categories.Find(id);

        if (categoryDb == null)
        {
            return NotFound();
        }
        
        return View(categoryDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Category? item = _db.Categories.Find(id);
        if (item == null)
        {
            return NotFound();
        }

        _db.Categories.Remove(item);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";

        return RedirectToAction("Index");
    }
}