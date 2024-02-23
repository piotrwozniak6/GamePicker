using System.ComponentModel.DataAnnotations;

namespace GamePickerWeb.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int Order { get; set; }
}