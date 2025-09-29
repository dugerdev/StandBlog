using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StandBlog.Data;
using StandBlog.Models.Entities;

namespace StandBlog.Controllers
{
    public class ContactController(
        ApplicationDbContext context,
        IValidator<Contact> validator
    ) : Controller
    {
        public IActionResult Us() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Us(Contact model)
        {
            var result = await validator.ValidateAsync(model);

            if (result.IsValid)
            {
                model.Id = Guid.CreateVersion7(TimeProvider.System.GetLocalNow()).ToString();
                model.CreatedOn = TimeProvider.System.GetLocalNow();

                await context.Contacts.AddAsync(model);
                await context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.ErrorCode, item.ErrorMessage);
            }

            return View(model);
        }
    }
}
