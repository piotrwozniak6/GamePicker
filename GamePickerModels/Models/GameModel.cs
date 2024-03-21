using System.ComponentModel.DataAnnotations;

namespace GamePickerModels.Models;

public class GameModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public string Publisher { get; set; }
    [Required]
    [Display(Name = "Regular Price")]
    [Range(1, 500)]
    public double RegularPrice { get; set; }
    [Required]
    [Display(Name = "Price for 1-50 units")]
    [Range(1, 500)]
    public double Price { get; set; }
    [Required]
    [Display(Name = "Price for 50+ units")]
    [Range(1, 500)]
    public double Price50 { get; set; }
    [Required]
    [Display(Name = "Price for 100+ units")]
    [Range(1, 500)]
    public double Price100 { get; set; }
}