using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.ViewComponents;

public class BannerViewComponent(ApplicationDbContext context) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        // En çok yorum almış son 6 blogu getiriyoruz
        var blogs = await context.Blogs
                                 .Include(b => b.Category)      // Blogun kategorisini dahil et
                                 .Include(b => b.Comments)      // Blogun yorumlarını dahil et
                                 .OrderByDescending(b => b.Comments != null ? b.Comments.Count : 0) // Yorum sayısına göre sırala
                                 .Take(6)                        // Sadece son 6 blogu al
                                 .ToListAsync();

        return View(blogs); // View'e blogları gönder
    }
}
