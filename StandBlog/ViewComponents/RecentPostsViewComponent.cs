using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.ViewComponents;

public class RecentPostsViewComponent(ApplicationDbContext context) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        // Son eklenen 3 blogu getir
        var latest = await context.Blogs
                                  .OrderByDescending(x => x.CreatedOn)
                                  .Take(3)
                                  .ToListAsync();

        return View(latest); // View'e gönder
    }
}
