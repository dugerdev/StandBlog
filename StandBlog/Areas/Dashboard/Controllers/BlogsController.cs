using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;
using StandBlog.Models.Entities;

namespace StandBlog.Areas.Dashboard.Controllers;

[Authorize(Roles = "Admin")]
[Area("Dashboard")]
public class BlogsController : Controller
{
    private readonly ApplicationDbContext _context;

    public BlogsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Dashboard/Blogs
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Blogs.Include(b => b.Category);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Dashboard/Blogs/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blog = await _context.Blogs
            .Include(b => b.Category)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (blog == null)
        {
            return NotFound();
        }

        return View(blog);
    }

    // GET: Dashboard/Blogs/Create
    public IActionResult Create()
    {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        return View();
    }

    // POST: Dashboard/Blogs/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Blog blog)
    {
        if (ModelState.IsValid)
        {
            blog.Id = Guid.CreateVersion7(TimeProvider.System.GetLocalNow()).ToString();
            blog.CreatedOn = TimeProvider.System.GetLocalNow();
            _context.Add(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", blog.CategoryId);
        return View(blog);
    }

    // GET: Dashboard/Blogs/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blog = await _context.Blogs.FindAsync(id);
        if (blog == null)
        {
            return NotFound();
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", blog.CategoryId);
        return View(blog);
    }

    // POST: Dashboard/Blogs/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, Blog blog)
    {
        if (id != blog.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                blog.ModifiedOn = TimeProvider.System.GetLocalNow();
                _context.Blogs.Update(blog);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(blog.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", blog.CategoryId);
        return View(blog);
    }

    // GET: Dashboard/Blogs/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blog = await _context.Blogs
            .Include(b => b.Category)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (blog == null)
        {
            return NotFound();
        }

        return View(blog);
    }

    // POST: Dashboard/Blogs/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var blog = await _context.Blogs.FindAsync(id);
        if (blog != null)
        {
            blog.DeletedOn = TimeProvider.System.GetLocalNow();
            blog.IsDeleted = true;
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BlogExists(string id)
    {
        return _context.Blogs.Any(e => e.Id == id);
    }
}
