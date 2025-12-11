using System.ComponentModel.DataAnnotations;

namespace Merchify.WebApp.Models;

public class Category
{
   public int Id { get; set; }

   [Required(ErrorMessage = "name field is required")]
   [MinLength(3, ErrorMessage = "name field must be at least 3 characters")]
   public required string Name { get; set; }
   public string? Description { get; set; }
}
