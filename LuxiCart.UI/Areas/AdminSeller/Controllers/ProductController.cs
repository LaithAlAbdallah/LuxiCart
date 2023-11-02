using LuxiCart.BL.IRepositories;
using LuxiCart.EF.Data;
using LuxiCart.EF.Models;
using LuxiCart.UI.Areas.AdminSeller.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Linq;

namespace LuxiCart.UI.Areas.AdminSeller.Controllers
{
    [Area("AdminSeller")]
    public class ProductController : Controller
    {

        #region Configuration

        public IBaseRepository<Product> _productbaseRepository;
        public UserManager<ApplicationUser> _UserManager;
        public AppDbContext _db;
        public IWebHostEnvironment _environment;
        public UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _signInManager;

        public ProductController(IBaseRepository<Product> productbaseRepository, UserManager<ApplicationUser> UserManager,
            AppDbContext db, IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _productbaseRepository = productbaseRepository;
            _UserManager = UserManager;
            _db = db;
            _environment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #endregion


        #region ProductViews
        public IActionResult ProductIndex()
        {
            var userId = _userManager.GetUserId(User);
            var seller = _db.sellers.FirstOrDefault(x => x.ApplicationUserId == userId);
            if (seller != null)
            {
                var products = _db.Products.Where(x => x.SellerId == seller.SellerId).ToList();

                return View(products);
            }
            return NotFound();
        }

        public IActionResult ViewItems(int id)
        {
            
            var productItems = _db.productItems.Where(x => x.ProductId == id).ToList();
            return View(productItems);
        }

        [HttpGet]
        public IActionResult EditItem(int id)
        {
            var item = _db.productItems.Find(id);

            if (item == null)
            {
                return NotFound();
            }
            int EProductId = item.ProductId;
            TempData["EProductId"] = EProductId;


            var sizes = new List<string>
            { "XS" , "S" , "M", "L", "XL", "XXL" };
            ViewData["sizes"] = sizes;

            ProductItemVM VM = new ProductItemVM
            {
               productItem= item,
               size= sizes
            };


            return View(VM);
        }

        [HttpPost]
        public IActionResult EditItem(ProductItemVM model , IFormFile file)
        {
            if (model.size == null || !model.size.Any())
            {
                ModelState.AddModelError("", "Please select at least one size.");
                return View(model);
            }
            string combinedSizes = string.Join(",", model.size.ToArray());
            int productId = (int)TempData["EProductId"]!;

            
            ProductItem Item = _db.productItems.FirstOrDefault(x=>x.ProductId == productId)!;

            if (Item == null)
            {
                return NotFound();
            }

            Item.Color = model.productItem!.Color;
            Item.QuantityInStock = model.productItem.QuantityInStock;
            Item.Price = model.productItem.Price;
            Item.ItemImage = UploadedFile(file);
            Item.Size = combinedSizes;


            _db.productItems.Update(Item);
            _db.SaveChanges();

            return RedirectToAction("ProductIndex", "Product");
        }
        #endregion


        #region AddProducts

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product model, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                model.Image = UploadedFile(file);
            }
            else
            {
                ModelState.AddModelError("", "Please Add an Image for your product");
                return View(model);
            }

            var user = _UserManager.GetUserId(User);
            var seller = _db.sellers.Where(x => x.ApplicationUserId == user).FirstOrDefault();

            if (seller != null)
            {
                model.SellerId = seller.SellerId;

                _productbaseRepository.Add(model);
                _productbaseRepository.SaveData();

                int productId = model.ProductId;
                TempData["productId"] = productId;

                return RedirectToAction("AddProductItem", "Product");

            }
            ModelState.AddModelError("", "No seller ID Found");
            return View(model);
        }

        [HttpGet]
        public IActionResult AddProductItem()
        {

            var sizes = new List<string>
            { "XS" , "S" , "M", "L", "XL", "XXL" };
            ViewData["sizes"] = sizes;

            return View();
        }

        [HttpPost]
        public IActionResult AddProductItem(ProductItemVM VM, IFormFile file)
        {
            int productId = (int)TempData["productId"]!;

            if (VM.size == null || !VM.size.Any())
            {
                ModelState.AddModelError("", "Please select at least one size.");
                return View(VM);
            }

            string combinedSizes = string.Join(",", VM.size.ToArray());

            ProductItem model = new ProductItem()
            {
                ProductId = productId,
                Color = VM.productItem!.Color,
                QuantityInStock = VM.productItem.QuantityInStock,
                Price = VM.productItem.Price,
                Size = combinedSizes,
                ItemImage = UploadedFile(file)
            };

            _db.productItems.Add(model);
            _db.SaveChanges();


            return RedirectToAction("AddProductItem", "Product");

        }
        #endregion


        #region Utilities
        public string UploadedFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string fileExtention = Path.GetExtension(file.FileName);
                string uniqueFileName = Guid.NewGuid().ToString() + fileExtention;
                string path = Path.Combine(_environment.WebRootPath, "Products");
                string filePath = Path.Combine(path, uniqueFileName);
                string relative = Path.Combine("Products", uniqueFileName);


                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }


                return "~/" + relative;

            }

            return null!;
        }
        #endregion


    }
}
