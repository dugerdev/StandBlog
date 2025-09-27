using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.ViewComponents;

public class BlogCommentsViewComponent(ApplicationDbContext context)
    : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var comments = await context.Comments
                                    .Where(x => x.BlogId == id)
                                    .ToListAsync();

        return View(comments);
    }
}
