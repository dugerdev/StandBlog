using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.ViewComponents;

public class RecentPostsViewComponent(ApplicationDbContext context)
    : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var latest = await context.Blogs
                                  .OrderBy(x => x.CreatedOn)
                                  .Take(3)
                                  .ToListAsync();
        return View(latest);
    }
}
