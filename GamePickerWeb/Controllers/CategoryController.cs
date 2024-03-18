using GamePickerDataAccess.Data;
using GamePickerDataAccess.Repository.IRepository;
using GamePickerModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamePickerWeb.Controllers;

public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork= unitOfWork;
    }
    public IActionResult Index()
    {
        List<Category> objCategoryList = _unitOfWork.CategoryRepository.GetAll().ToList();
        
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
            _unitOfWork.CategoryRepository.Add(item);
            _unitOfWork.Save();
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

        Category? categoryDb = _unitOfWork.CategoryRepository.Get(u => u.Id == id);

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
            _unitOfWork.CategoryRepository.Update(item);
            _unitOfWork.Save();
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

        Category? item = _unitOfWork.CategoryRepository.Get(u => u.Id == id);

        if (item == null)
        {
            return NotFound();
        }
        
        return View(item);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Category? item = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
        if (item == null)
        {
            return NotFound();
        }

        _unitOfWork.CategoryRepository.Remove(item);
        _unitOfWork.Save();
        TempData["success"] = "Category deleted successfully";

        return RedirectToAction("Index");
    }
}