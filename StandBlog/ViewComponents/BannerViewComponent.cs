using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.ViewComponents;

public class BannerViewComponent(ApplicationDbContext context) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        // En çok yorum almış son 6 blogu getiriyoruz
        // Önce tüm blogları çekip, sonra memory'de sıralıyoruz
        // (EF Core, Include edilmiş collection'ın Count'ını OrderBy içinde kullanamaz)
        var allBlogs = await context.Blogs
                                    .Include(b => b.Category)
                                    .Include(b => b.Comments)
                                    .ToListAsync();

        // Memory'de yorum sayısına göre sırala ve en çok yorum alan 6 blogu al
        var blogs = allBlogs
                    .OrderByDescending(b => b.Comments?.Count ?? 0)
                    .ThenByDescending(b => b.CreatedOn)
                    .Take(6)
                    .ToList();

        return View(blogs);
    }
}
