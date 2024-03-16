using System.ComponentModel.DataAnnotations;

namespace GamePickerModels.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(25)]
    public string Name { get; set; }
    [Range(1, 50, ErrorMessage = "Order must be between 1-50")]
    public int Order { get; set; }
}