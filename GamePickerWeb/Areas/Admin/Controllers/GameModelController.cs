using GamePickerDataAccess.Data;
using GamePickerDataAccess.Repository.IRepository;
using GamePickerModels.Models;
using GamePickerModels.ViewModels;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamePickerWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class GameModelController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public GameModelController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork= unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }
    public IActionResult Index()
    {
        List<GameModel> objGameModelList = _unitOfWork.GameModelRepository.GetAll(includeItems:"Category").ToList();
        return View(objGameModelList);
    }

    public IActionResult Upsert(int? id)
    {
        IEnumerable<SelectListItem> Categories = _unitOfWork.CategoryRepository.GetAll().Select(u=> new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });

        GameModelVM gameModelVm = new()
        {
            Categories = Categories,
            GameModel = new GameModel()
        };
        if (id == null || id == 0)
        {
            return View(gameModelVm);
        }
        else
        {
            gameModelVm.GameModel = _unitOfWork.GameModelRepository.Get(u => u.Id == id);
            return View(gameModelVm);
        }
            
    }
    [HttpPost]
    public IActionResult Upsert(GameModelVM gameModelVm, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images/gameModel");

                if (!string.IsNullOrEmpty(gameModelVm.GameModel.ImageUrl))
                {
                    var oldImagePath = Path.Combine(wwwRootPath, gameModelVm.GameModel.ImageUrl.TrimStart('/'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                
                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                gameModelVm.GameModel.ImageUrl = @"/images/gameModel/" + fileName;
            }

            if (gameModelVm.GameModel.Id == 0)
            {
                _unitOfWork.GameModelRepository.Add(gameModelVm.GameModel);
            }
            else
            {
                _unitOfWork.GameModelRepository.Update(gameModelVm.GameModel);
            }
            _unitOfWork.Save();
            TempData["success"] = "GameModel created successfully";
            
            return RedirectToAction("Index");
        }
        else
        {
            gameModelVm.Categories = _unitOfWork.CategoryRepository.GetAll().Select(u=> new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(gameModelVm);
        }
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