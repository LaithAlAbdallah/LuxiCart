using LuxiCart.EF.Data;
using LuxiCart.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LuxiCart.UI.Controllers
{
	public class ProductController : Controller
	{
		public AppDbContext _db;
        public ProductController(AppDbContext db)
        {
			_db = db;
        }

		//SCId = Sub-Category Id
		//PCId = Parent Category Id
		[HttpGet]
        public IActionResult Index(int? SCId, int? PCId)
		{
			
			var filteredProducts = _db.Products.AsQueryable();

			if (SCId != null)
			{
				filteredProducts = filteredProducts.Where(x => x.ProductCategoryId == SCId);
			}

			if (PCId != null)
			{
				filteredProducts = filteredProducts.Where(x => x.ProductParentCategoryId == PCId);
			}

			return View(filteredProducts.ToList());
		}

		[HttpGet]
		public IActionResult ProductItem(int ProdId)
		{
			var prodItems = _db.productItems.Where(x => x.ProductId == ProdId).ToList();
			var MainProduct = _db.Products.FirstOrDefault(x => x.ProductId == ProdId);

			var VM = new ProductItemVM
			{
				productItems = prodItems
			};

			if (VM != null)
			{
				return View(VM);
			}
			return NotFound();
		}
	}
}
