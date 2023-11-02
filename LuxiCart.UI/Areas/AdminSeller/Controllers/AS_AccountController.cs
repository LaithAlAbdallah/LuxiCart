using LuxiCart.BL.IRepositories;
using LuxiCart.EF.Data;
using LuxiCart.EF.Models;
using LuxiCart.UI.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LuxiCart.UI.Areas.AdminSeller.Controllers
{
    [Area("AdminSeller")]
    public class AS_AccountController : Controller
    {
        
        #region Configuration

        private UserManager<ApplicationUser> _UserManager;
        public IBaseRepository<Seller> _SellerRepository;
        public IBaseRepository<Address> _AddressRepository;
        private SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        private AppDbContext _db;

        public AS_AccountController(UserManager<ApplicationUser> UserManager, IBaseRepository<Seller> SellerRepository,
         SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager,
         IBaseRepository<Address> addressRepository, AppDbContext db)
        {
            _UserManager = UserManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _SellerRepository = SellerRepository;
            _AddressRepository = addressRepository;
            _db = db;

        }
        #endregion


        #region Registration

        [HttpGet]
        public IActionResult AS_Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AS_Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    ApplicationUser newUser = new ApplicationUser
                    {
                        
                        UserName = model.Email,
                        Email = model.Email,

                    };


                    var result = await _UserManager.CreateAsync(newUser, model.Password!);
                    await _UserManager.AddToRoleAsync(newUser, "Seller");

                    if (result.Succeeded)
                    {
                        Seller seller = new Seller
                        {
                            FullName = model.FullName,
                            PhoneNumber = model.PhoneNumber,
                            ApplicationUserId = newUser.Id,
                            Gender = model.Gender
                        };
                        _SellerRepository.Add(seller);
                        _SellerRepository.SaveData();

                        int sellerId = seller.SellerId;
                        TempData["sellerId"] = sellerId;

                        return RedirectToAction("Address");
                    }
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError(err.Code, err.Description);
                    }
                    return View(model);
                }
                ModelState.AddModelError("", "This Email is already Used");
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Address()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Address(Address model)
        {
            if (ModelState.IsValid)
            {

                _AddressRepository.Add(model);
                _AddressRepository.SaveData();
                
                int addressId = model.AddressId;
                int sellerId = (int)TempData["sellerId"]!;
                TempData["addressId"] = addressId;

                return RedirectToAction("SellerInformation");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SellerInformation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SellerInformation(SellerInfo model)
        {
            if (ModelState.IsValid)
            {
                int sellerId = (int)TempData["sellerId"]!;
                int addressId = (int)TempData["addressId"]!;

                model.SellerId = sellerId;
                model.AddressId = addressId;

                

                var result = await _db.SellerInfos.AddAsync(model);
                _db.SaveChanges();

                int sellerInfoId = model.SellerInfoId;
                TempData["sellerInfoId"] = sellerInfoId;

                return RedirectToAction("ProofOfIdentity");

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ProofOfIdentity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProofOfIdentity(ProofOfIdentity model)
        {
            if (ModelState.IsValid)
            {
                int sellerInfoId = (int)TempData["sellerInfoId"]!;

                model.SellerInfoId = sellerInfoId;

                _db.proofOfIdentities.Add(model);
                _db.SaveChanges();

                return RedirectToAction("SellerCreditCard");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SellerCreditCard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SellerCreditCard(SellerCreditCard model)
        {
            if (ModelState.IsValid)
            {
                int sellerInfoId = (int)TempData["sellerInfoId"]!;

                model.SellerInfoId = sellerInfoId;

                _db.sellerCreditCards.Add(model);
                _db.SaveChanges();
                return RedirectToAction("AS_Login");

                
            }
            return View(model);
        }
        #endregion



        #region Login



        [HttpGet]
        public IActionResult AS_Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AS_Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByEmailAsync(model.Email!);
                var role = await _UserManager.GetRolesAsync(user!);

                if (role.Contains("Seller"))
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    ModelState.AddModelError("", "Invalid Email or Password");
                    return View(model);
                }
                else if (role.Contains("Admin"))
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    ModelState.AddModelError("", "Invalid Email or Password");
                    return View(model);
                }
                ModelState.AddModelError("", "You dont have Seller account! Please create one");
                return View(model);
            }
            return View(model);
        }

        public async Task<IActionResult> Logout () 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("AS_Login");
        }

        #endregion



       




        //#region Roles

        //public IActionResult CreateRole()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        IdentityRole role = new IdentityRole
        //        {
        //            Name = model.RoleName
        //        };
        //        var result = await _roleManager.CreateAsync(role);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Login");
        //        }
        //        ModelState.AddModelError("", "Not Created");
        //        return View(model);
        //    }
        //    return View(model);
        //}

        //#endregion
    }
}
