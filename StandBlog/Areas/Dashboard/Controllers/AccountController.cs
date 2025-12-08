using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StandBlog.Areas.Dashboard.Models;
using StandBlog.Models.Entities;
using System.Threading.Tasks;

namespace StandBlog.Areas.Dashboard.Controllers;

[Area("Dashboard")]
public class AccountController(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    IValidator<RegisterViewModel> registerValidator,
    IValidator<LoginViewModel> loginValidator
    ) : Controller
{
    public IActionResult Register() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var result = await registerValidator.ValidateAsync(model);

        if (result.IsValid)
        {
            var user = new ApplicationUser
            {
                Id = Guid.CreateVersion7(TimeProvider.System.GetLocalNow()).ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = DateOnly.Parse(model.DateOfBirth.ToShortDateString()),
                Email = model.Email,
                UserName = $"{model.LastName.ToLower()}.{model.FirstName.ToLower()}",
                LastLogin = DateTimeOffset.Now,
                IsActive = true,
                CreatedOn = DateTimeOffset.Now
            };

            var identityResult = await userManager.CreateAsync(user, model.Password);

            if (identityResult.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(user, "User");

                if (roleResult.Succeeded) return RedirectToAction("Login");

                foreach (var role in roleResult.Errors)
                    ModelState.AddModelError(role.Code, role.Description);
            }

            foreach (var identity in identityResult.Errors)
                ModelState.AddModelError(identity.Code, identity.Description);
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);

        return View(model);
    }

    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await loginValidator.ValidateAsync(model);

        if (result.IsValid)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user is not null)
            {
                var signinResult = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                if (signinResult.Succeeded)
                {
                    // Admin rolü kontrolü
                    var isAdmin = await userManager.IsInRoleAsync(user, "Admin");
                    if (isAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Dashboard" });
                    }
                    else
                    {
                        // Admin değilse public home'a yönlendir
                        await signInManager.SignOutAsync();
                        ModelState.AddModelError(string.Empty, "You do not have permission to access the dashboard.");
                        return View(model);
                    }
                }
            }

            ModelState.AddModelError(string.Empty, "Email or Password not valid.");
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home", new { area = "" });
    }
}
