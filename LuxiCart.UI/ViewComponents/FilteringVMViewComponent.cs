using LuxiCart.EF.Data;
using LuxiCart.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LuxiCart.UI.ViewComponents
{
    public class FilteringVMViewComponent : ViewComponent
    {
        public AppDbContext _db;
        public FilteringVMViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var VM = new FilteringVM
            {
                productParentCategories = _db.productParentCategories.ToList(),
                productCategories = _db.ProductSubCategories.ToList(),
                products = _db.Products.ToList()
            };

            return View(VM);
        }
    }
}
