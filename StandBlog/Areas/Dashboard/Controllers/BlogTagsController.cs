using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;
using StandBlog.Models.Entities;

namespace StandBlog.Areas.Dashboard.Controllers;

[Authorize]
[Area("Dashboard")]
public class BlogTagsController : Controller
{
    private readonly ApplicationDbContext _context;

    public BlogTagsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Dashboard/BlogTags
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.BlogTags.Include(b => b.Blog).Include(b => b.Tag);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Dashboard/BlogTags/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blogTag = await _context.BlogTags
            .Include(b => b.Blog)
            .Include(b => b.Tag)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (blogTag == null)
        {
            return NotFound();
        }

        return View(blogTag);
    }

    // GET: Dashboard/BlogTags/Create
    public IActionResult Create()
    {
        ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Title");
        ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name");
        return View();
    }

    // POST: Dashboard/BlogTags/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BlogTag blogTag)
    {
        if (ModelState.IsValid)
        {
            blogTag.Id = Guid.CreateVersion7(TimeProvider.System.GetLocalNow()).ToString();
            blogTag.CreatedOn = TimeProvider.System.GetLocalNow();
            _context.Add(blogTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Title", blogTag.BlogId);
        ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", blogTag.TagId);
        return View(blogTag);
    }

    // GET: Dashboard/BlogTags/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blogTag = await _context.BlogTags.FindAsync(id);
        if (blogTag == null)
        {
            return NotFound();
        }
        ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Title", blogTag.BlogId);
        ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", blogTag.TagId);
        return View(blogTag);
    }

    // POST: Dashboard/BlogTags/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, BlogTag blogTag)
    {
        if (id != blogTag.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                blogTag.ModifiedOn = TimeProvider.System.GetLocalNow();
                _context.Update(blogTag);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogTagExists(blogTag.Id))
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
        ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Title", blogTag.BlogId);
        ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", blogTag.TagId);
        return View(blogTag);
    }

    // GET: Dashboard/BlogTags/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blogTag = await _context.BlogTags
            .Include(b => b.Blog)
            .Include(b => b.Tag)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (blogTag == null)
        {
            return NotFound();
        }

        return View(blogTag);
    }

    // POST: Dashboard/BlogTags/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var blogTag = await _context.BlogTags.FindAsync(id);
        if (blogTag != null)
        {
            blogTag.DeletedOn = TimeProvider.System.GetLocalNow();
            blogTag.IsDeleted = true;
            _context.BlogTags.Update(blogTag);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BlogTagExists(string id)
    {
        return _context.BlogTags.Any(e => e.Id == id);
    }
}
