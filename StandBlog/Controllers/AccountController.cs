using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StandBlog.Areas.Dashboard.Models;
using StandBlog.Models.Entities;
using System.Threading.Tasks;

namespace StandBlog.Controllers
{
    public class AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IValidator<RegisterViewModel> registerValidator,
        IValidator<LoginViewModel> loginValidator
        ) : Controller
    {
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var result = await loginValidator.ValidateAsync(model);

            if (result.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user is not null)
                {
                    var signinResult = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    if (signinResult.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Email or Password not valid.");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await registerValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                TempData["ErrorMessage"] = "Please correct the errors and try again.";
                return View(model);
            }

            try
            {
                var user = new ApplicationUser
                {
                    Id = Guid.CreateVersion7(TimeProvider.System.GetLocalNow()).ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = DateOnly.FromDateTime(model.DateOfBirth.Date),
                    Email = model.Email,
                    UserName = model.Email, // Email'i username olarak kullan
                    EmailConfirmed = false,
                    LastLogin = DateTimeOffset.Now,
                    IsActive = true,
                    CreatedOn = DateTimeOffset.Now
                };

                var identityResult = await userManager.CreateAsync(user, model.Password);

                if (identityResult.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, "User");

                    if (roleResult.Succeeded)
                    {
                        TempData["SuccessMessage"] = "Registration successful! Please login to continue.";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        // Role atama başarısız oldu ama kullanıcı oluşturuldu, yine de login'e yönlendir
                        foreach (var role in roleResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, role.Description);
                        }
                        TempData["SuccessMessage"] = "Registration successful! Please login to continue.";
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    foreach (var identity in identityResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, identity.Description);
                    }
                    TempData["ErrorMessage"] = "Registration failed. Please check your information and try again.";
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred during registration. Please try again.");
                TempData["ErrorMessage"] = "An unexpected error occurred. Please try again.";
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

