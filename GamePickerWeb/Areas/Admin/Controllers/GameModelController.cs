using GamePickerDataAccess.Data;
using GamePickerDataAccess.Repository.IRepository;
using GamePickerModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamePickerWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class GameModelController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public GameModelController(IUnitOfWork unitOfWork)
    {
        _unitOfWork= unitOfWork;
    }
    public IActionResult Index()
    {
        List<GameModel> objGameModelList = _unitOfWork.GameModelRepository.GetAll().ToList();
        
        return View(objGameModelList);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(GameModel item)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.GameModelRepository.Add(item);
            _unitOfWork.Save();
            TempData["success"] = "GameModel created successfully";
            
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

        GameModel? gameModelDb = _unitOfWork.GameModelRepository.Get(u => u.Id == id);

        if (gameModelDb == null)
        {
            return NotFound();
        }
        
        return View(gameModelDb);
    }
    [HttpPost]
    public IActionResult Edit(GameModel item)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.GameModelRepository.Update(item);
            _unitOfWork.Save();
            TempData["success"] = "GameModel updated successfully";
            
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

        GameModel? item = _unitOfWork.GameModelRepository.Get(u => u.Id == id);

        if (item == null)
        {
            return NotFound();
        }
        
        return View(item);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        GameModel? item = _unitOfWork.GameModelRepository.Get(u => u.Id == id);
        if (item == null)
        {
            return NotFound();
        }

        _unitOfWork.GameModelRepository.Remove(item);
        _unitOfWork.Save();
        TempData["success"] = "GameModel deleted successfully";

        return RedirectToAction("Index");
    }
}