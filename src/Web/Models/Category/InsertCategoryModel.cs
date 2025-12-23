namespace Merchify.Web.Models.Category;

public sealed record InsertCategoryModel
{
   [Required]
   public required string Name { get; init; }

   public string? Description { get; init; }
}