namespace Merchify.Web.Models.Category;

public sealed record CategoryModel
{
   public int Id { get; init; }
   
   [Required]
   [MinLength(3)]
   public required string Name { get; init; }
   public string? Description { get; init; }
}