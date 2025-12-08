using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.ViewComponents;

public class BlogCommentsViewComponent(ApplicationDbContext context) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        // Belirli bir bloga ait tüm yorumları getir
        var comments = await context.Comments
                                    .Where(c => c.BlogId == id) // BlogId eşleşen yorumlar
                                    .ToListAsync();

        return View(comments); // View'e yorumları gönder
    }
}
