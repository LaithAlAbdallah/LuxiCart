using Microsoft.AspNetCore.Mvc;

namespace LuxiCart.UI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult CustomerInfo()
        {
            return View();
        }
    }
}
