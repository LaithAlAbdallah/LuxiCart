using LuxiCart.BL.IRepositories;
using LuxiCart.EF.Data;
using LuxiCart.EF.Models;
using LuxiCart.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LuxiCart.UI.ViewComponents
{
	public class NavBarVMViewComponent : ViewComponent
	{
		public IBaseRepository<ProductParentCategory> _PPCbaseRepository;
		public IBaseRepository<ProductCategory> _PCbaseRepository;
        public AppDbContext _db;

        public NavBarVMViewComponent(IBaseRepository<ProductParentCategory> PPCbaseRepository,
            IBaseRepository<ProductCategory> PCbaseRepository, AppDbContext db)
        {
            _PPCbaseRepository = PPCbaseRepository;
            _PCbaseRepository = PCbaseRepository;
            _db = db;
        }


        public IViewComponentResult Invoke()
        {
            var VM = new NavBarVM
            {
                productParentCategories = _db.productParentCategories.ToList(),
                productCategories = _db.ProductSubCategories.ToList()
            };
            return View(VM);
        }
    }
}
