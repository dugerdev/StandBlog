using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.ViewComponents;

public class CategoriesViewComponent(ApplicationDbContext context)
    : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await context.Categories.ToListAsync();

        return View(categories);
    }
}
