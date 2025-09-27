using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.ViewComponents;

public class BannerViewComponent(ApplicationDbContext context)
    : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync() 
    {
        var blogs = await context.Blogs
                                 .Include(x => x.Category)
                                 .Include(x => x.Comments)
                                 .OrderByDescending(x => x.Comments.Count)
                                 .Take(6)
                                 .ToListAsync();

        return View(blogs);
    }
}
