using LuxiCart.BL.IRepositories;
using LuxiCart.EF.Data;
using LuxiCart.EF.Models;
using LuxiCart.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LuxiCart.UI.Controllers
{
    public class HomeController : Controller
    {
        public IBaseRepository<ProductCategory> _ProductCategoryRepository;
        public AppDbContext _db;
        public HomeController(IBaseRepository<ProductCategory> ProductCategoryRepository, AppDbContext db)
        {
            _ProductCategoryRepository = ProductCategoryRepository;
            _db = db;
        }

        public IActionResult Index()
        {
            var productParentCategory = _db.productParentCategories.ToList();
            var productCategory = _db.ProductSubCategories.ToList();
            var products = _db.Products.ToList();

            var VM = new HomeVM
            {
                productParentCategories = productParentCategory,
                productCategories = productCategory,
                products = products
            };

            return View(VM);
        }
    }
}
