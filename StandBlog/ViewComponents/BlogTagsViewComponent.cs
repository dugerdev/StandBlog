using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.ViewComponents;

public class BlogTagsViewComponent(ApplicationDbContext context) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        // Belirli bir bloga ait tüm etiketleri getir
        var tags = await context.BlogTags
                                .Include(bt => bt.Tag)   // Tag bilgisini de dahil et
                                .Where(bt => bt.BlogId == id) // Sadece ilgili BlogId'ye sahip kayıtlar
                                .ToListAsync();

        return View(tags); // View'e gönder
    }
}
