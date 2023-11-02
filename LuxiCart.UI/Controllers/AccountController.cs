using LuxiCart.BL.IRepositories;
using LuxiCart.EF.Data;
using LuxiCart.EF.Models;
using LuxiCart.EF.Repositories;
using LuxiCart.UI.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace LuxiCart.UI.Controllers
{
	public class AccountController : Controller
	{

        
        #region Configuration

        private UserManager<ApplicationUser> _UserManager;
        public IBaseRepository<Customer> _customerRepository;
        private SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> UserManager, IBaseRepository<Customer> customerRepository,
         SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _UserManager = UserManager;
            _customerRepository = customerRepository;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        #endregion


        #region Login

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
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
                    await _UserManager.AddToRoleAsync(newUser, "Customer");

                    if (result.Succeeded)
                    {
                        Customer customer = new Customer
                        {
                            FullName = model.FullName,
                            PhoneNumber = model.PhoneNumber,
                            ApplicationUserId = newUser.Id,
                            Gender = model.Gender
                        };
                        _customerRepository.Add(customer);
                        _customerRepository.SaveData();
                        return RedirectToAction("Login");
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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByEmailAsync(model.Email!);
                var role = await _UserManager.GetRolesAsync(user!);

                if (role.Contains("Customer"))
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Invalid Email or Password");
                    return View(model);
                }
                ModelState.AddModelError("", "You dont have account! Please create account");

            }
            return View(model);
        }

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login");
		}


		#endregion



		#region Roles

		public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid) 
            {
                IdentityRole role = new IdentityRole
                {
                    Name=model.RoleName
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "Not Created");
                return View(model);
            }
            return View(model);
        }

        #endregion

    }
}
