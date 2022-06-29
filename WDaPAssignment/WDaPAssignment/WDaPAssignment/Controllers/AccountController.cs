using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WDaPAssignment.Models;

namespace WDaPAssignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser<int>> signInManager;
        private readonly UserManager<IdentityUser<int>> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        public AccountController(UserManager<IdentityUser<int>> userManager,
            SignInManager<IdentityUser<int>> signInManager, RoleManager<IdentityRole<int>> _roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = _roleManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new IdentityUser<int>
                {
                    UserName = model.Email,
                    Email = model.Email,
                  
                };
                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);
                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    var role = roleManager.Roles.Where(x => x.Name == "Customer").FirstOrDefault();
                    await userManager.AddToRoleAsync(user, role.Name);
                    //if (signInManager.IsSignedIn(User) && User.IsInRole("Manager"))
                    //{
                    //    return null;
                    //}
                    //await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "account");
                }
                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("index", "customer");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                      
                    HttpContext.Session.SetString("CustomerId", "0");
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "customer");
                    }

                   
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
       
    }
}