using Microsoft.AspNetCore.Mvc;

namespace GamePickerWeb.Controllers;

public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}