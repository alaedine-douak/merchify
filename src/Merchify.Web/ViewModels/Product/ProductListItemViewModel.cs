namespace Merchify.Web.ViewModels.Product;

public sealed record ProductListItemViewModel
{
   public List<ProductItemViewModel> Items { get; set; } = [];
}
