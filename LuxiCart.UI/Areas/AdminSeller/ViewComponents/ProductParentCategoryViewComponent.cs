using LuxiCart.BL.IRepositories;
using LuxiCart.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuxiCart.UI.Areas.AdminSeller.ViewComponents
{
    public class ProductParentCategoryViewComponent : ViewComponent
    {
        public IBaseRepository<ProductParentCategory> _baseRepository;
        public ProductParentCategoryViewComponent(IBaseRepository<ProductParentCategory> baseRepository)
        {
            _baseRepository = baseRepository;
            
        }

        public IViewComponentResult Invoke()
        {
            var productParentCategory = _baseRepository.GetAll().OrderBy(x => x.ProductParentCategoryId);
            return View(productParentCategory);
        }
    }
}
