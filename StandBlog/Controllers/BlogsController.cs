using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;
using StandBlog.Models.Entities;

namespace StandBlog.Controllers;

public class BlogsController(
    ApplicationDbContext context,
    IValidator<Comment> validator
    ) : Controller
{
    public async Task<IActionResult> Detail(string id)
    {
        var blog = await context.Blogs
                                .Include(x => x.Category)
                                .Include(x => x.Comments)
                                .Where(x => x.Id == id)
                                .SingleOrDefaultAsync();
        return View(blog);
    }

    public async Task<IActionResult> Category(string id)
    {
        var blogs = await context.Blogs
                                 .Include(x => x.Category)
                                 .Include(x => x.Comments)
                                 .Where(x => x.CategoryId == id)
                                 .ToListAsync();
        return View(blogs);
    }

    public async Task<IActionResult> Tag(string id)
    {
        var blogs = await context.BlogTags
                                 .Include(x => x.Blog)
                                 .ThenInclude(x => x.Category)
                                 .Include(x => x.Blog)
                                 .ThenInclude(x => x.Comments)
                                 .Where(x => x.TagId == id)
                                 .ToListAsync();

        return View(blogs);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CommentAdd(Comment model)
    {
        var result = await validator.ValidateAsync(model);

        if (result.IsValid)
        {
            model.Id = Guid.CreateVersion7(TimeProvider.System.GetLocalNow()).ToString();
            model.CreatedOn = TimeProvider.System.GetLocalNow();

            await context.Comments.AddAsync(model);
            await context.SaveChangesAsync();

            return RedirectToAction("Detail", new { id = model.BlogId });
        }

        foreach (var item in result.Errors)
            ModelState.AddModelError(item.ErrorCode, item.ErrorMessage);

        return RedirectToAction("Detail", "Blogs");
    }
}
