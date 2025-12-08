using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.ViewComponents;

public class TagCloudsViewComponent(ApplicationDbContext context) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        // Tüm tagleri getir
        var tags = await context.Tags.ToListAsync();

        return View(tags); // View'e gönder
    }
}
