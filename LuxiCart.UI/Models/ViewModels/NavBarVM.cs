using LuxiCart.EF.Models;
using System.Collections.Generic;

namespace LuxiCart.UI.Models.ViewModels
{
	public class NavBarVM
	{ 
		public List<ProductParentCategory>? productParentCategories { get; set; }
		public List<ProductCategory>? productCategories { get; set; }
	}
}
