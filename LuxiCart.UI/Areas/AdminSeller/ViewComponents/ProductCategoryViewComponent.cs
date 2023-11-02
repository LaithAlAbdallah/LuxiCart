using LuxiCart.BL.IRepositories;
using LuxiCart.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuxiCart.UI.Areas.AdminSeller.ViewComponents
{
    public class ProductCategoryViewComponent : ViewComponent
    {
        public IBaseRepository<ProductCategory> _pbaseRepository;
        public ProductCategoryViewComponent(IBaseRepository<ProductCategory> pbaseRepository)
        {
            _pbaseRepository = pbaseRepository;
        }

        public IViewComponentResult Invoke()
        {
            var productCategory = _pbaseRepository.GetAll().OrderBy(x => x.CategoryName);
            return View(productCategory);
        }
    }
}
