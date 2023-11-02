using LuxiCart.BL.IRepositories;
using LuxiCart.EF.Data;
using LuxiCart.EF.Models;
using LuxiCart.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LuxiCart.UI.Areas.AdminSeller.Controllers
{
    [Area("AdminSeller")]
    public class CategoryController : Controller
    {

        #region Configuration
        public IBaseRepository<ProductParentCategory> _ProductParentCategorybaseRepository;
        public IBaseRepository<ProductCategory> _ProductCategorybaseRepository;
        public IWebHostEnvironment _environment;
        public AppDbContext _db;


        public CategoryController(IBaseRepository<ProductParentCategory> ProductParentCategorybaseRepository,
            IBaseRepository<ProductCategory> productCategorybaseRepository,
            IWebHostEnvironment environment, AppDbContext db)
        {
            _ProductParentCategorybaseRepository = ProductParentCategorybaseRepository;
            _ProductCategorybaseRepository = productCategorybaseRepository;
            _environment = environment;
            _db= db;
        }
        #endregion


        #region IndexAndEdit
        public IActionResult CategoriesIndex()
        {
            var ParentCate = _db.productParentCategories.ToList();
            var SubCate = _db.ProductSubCategories.ToList();

            var VM = new HomeVM
            {
                productParentCategories = ParentCate,
                productCategories = SubCate
            };
            
            return View(VM);
        }

        [HttpGet]
        public IActionResult EditParent(int id)
        {
            var data = _db.productParentCategories.Find(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult EditParent(ProductParentCategory model, IFormFile file)
        {
            var category = _db.productParentCategories.Find(model.ProductParentCategoryId);
            if (category == null)
            {
                return NotFound();
            }

            category.ParentCategoryName = model.ParentCategoryName;
            category.ParentCategoryImage = UploadedFile(file);

            _db.productParentCategories.Update(category);
            _db.SaveChanges();

            return RedirectToAction("CategoriesIndex");
        }
        #endregion




        #region AddCategories
        [HttpGet]
        public IActionResult AddParent() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddParent(ProductParentCategory model, IFormFile file) 
        {
            model.ParentCategoryImage = UploadedFile(file);

            _ProductParentCategorybaseRepository.Add(model);
            _ProductParentCategorybaseRepository.SaveData();

            TempData["SuccessMessage"] = "Added successfully";

            return RedirectToAction("CategoriesIndex");
        }

        [HttpGet]
        public IActionResult AddSub() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSub(ProductCategory model)
        {
            _ProductCategorybaseRepository.Add(model);
            _ProductCategorybaseRepository.SaveData();

            TempData["SuccessMessage"] = "Added successfully";

            return RedirectToAction("CategoriesIndex");
        }


        #endregion

        #region Promotion

        #endregion


        public string UploadedFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string fileExtention = Path.GetExtension(file.FileName);
                string uniqueFileName = Guid.NewGuid().ToString() + fileExtention;
                string path = Path.Combine(_environment.WebRootPath, "Category");
                string filePath = Path.Combine(path, uniqueFileName);
                string relative = Path.Combine("Category", uniqueFileName);


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
    }
}
