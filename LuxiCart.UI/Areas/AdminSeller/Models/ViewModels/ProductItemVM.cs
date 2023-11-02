using LuxiCart.EF.Models;

namespace LuxiCart.UI.Areas.AdminSeller.Models.ViewModels
{
    public class ProductItemVM
    {
        public ProductItem? productItem { get; set; }
        public List<string>? size { get; set; }
    }
}
