using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;
using StandBlog.Models.Entities;

namespace StandBlog.Areas.Dashboard.Controllers;

[Authorize]
[Area("Dashboard")]
public class CategoriesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Dashboard/Categories
    public async Task<IActionResult> Index()
    {
        return View(await _context.Categories.ToListAsync());
    }

    // GET: Dashboard/Categories/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var category = await _context.Categories
            .FirstOrDefaultAsync(m => m.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    // GET: Dashboard/Categories/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Dashboard/Categories/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category category)
    {
        if (ModelState.IsValid)
        {
            category.Id = Guid.CreateVersion7(TimeProvider.System.GetLocalNow()).ToString();
            category.CreatedOn = TimeProvider.System.GetLocalNow();
            _context.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    // GET: Dashboard/Categories/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    // POST: Dashboard/Categories/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, Category category)
    {
        if (id != category.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                category.ModifiedOn = TimeProvider.System.GetLocalNow();
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.Id))
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
        return View(category);
    }

    // GET: Dashboard/Categories/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var category = await _context.Categories
            .FirstOrDefaultAsync(m => m.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    // POST: Dashboard/Categories/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            category.DeletedOn = TimeProvider.System.GetLocalNow();
            category.IsDeleted = true;
            _context.Categories.Update(category);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CategoryExists(string id)
    {
        return _context.Categories.Any(e => e.Id == id);
    }
}
