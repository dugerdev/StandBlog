using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;

namespace StandBlog.Controllers;

public class HomeController(ApplicationDbContext context)
    : Controller
{
    public async Task<IActionResult> Index()
    {
        var blogs = await context.Blogs
                                 .OrderByDescending(x => x.CreatedOn)
                                 .Take(6)
                                 .ToListAsync();
        return View(blogs); 
    }
}
