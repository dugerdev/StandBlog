using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;
using StandBlog.Models.Entities;

namespace StandBlog.Controllers
{
    public class HomeController(ApplicationDbContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                var blogs = await context.Blogs
                                         .Include(x => x.Category)
                                         .Include(x => x.Comments)
                                         .OrderByDescending(x => x.CreatedOn)
                                         .Take(6)
                                         .ToListAsync();

                return View(blogs);
            }
            catch
            {
                // Log the exception (you can add logging here)
                return View(new List<Blog>());
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
