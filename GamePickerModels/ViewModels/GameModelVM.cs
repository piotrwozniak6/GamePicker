using System.Reflection.PortableExecutable;
using GamePickerModels.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamePickerModels.ViewModels;

public class GameModelVM
{
    public GameModel GameModel { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> Categories { get; set; }
}