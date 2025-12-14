using System.ComponentModel.DataAnnotations;

namespace Merchify.Web.Models;

public class CategoryVm
{
   [Required(ErrorMessage = "name field is required")]
   [MinLength(3, ErrorMessage = "name field must be at least 3 characters")]
   public string Name { get; set; } = string.Empty;
   public string? Description { get; set; }
}
