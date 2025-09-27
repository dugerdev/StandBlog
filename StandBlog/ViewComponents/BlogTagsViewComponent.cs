using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.ViewComponents;

public class BlogTagsViewComponent(ApplicationDbContext context)
    : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var tags = await context.BlogTags
                                .Include(x => x.Tag)
                                .Where(x => x.BlogId == id)
                                .ToListAsync();
        return View(tags);
    }
}
