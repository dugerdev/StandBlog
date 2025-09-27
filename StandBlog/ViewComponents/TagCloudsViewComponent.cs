using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.ViewComponents;

public class TagCloudsViewComponent(ApplicationDbContext context)
    : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var tags = await context.Tags.ToListAsync();

        return View(tags);
    }
}
