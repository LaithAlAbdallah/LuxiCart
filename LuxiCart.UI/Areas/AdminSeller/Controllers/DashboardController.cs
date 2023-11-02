using Microsoft.AspNetCore.Mvc;

namespace LuxiCart.UI.Areas.AdminSeller.Controllers
{
	[Area("AdminSeller")]
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
