using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;
using StandBlog.Models.Entities;

namespace StandBlog.Areas.Dashboard.Controllers;

[Authorize(Roles = "Admin")]
[Area("Dashboard")]
public class TagsController : Controller
{
    private readonly ApplicationDbContext _context;

    public TagsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Dashboard/Tags
    public async Task<IActionResult> Index()
    {
        return View(await _context.Tags.ToListAsync());
    }

    // GET: Dashboard/Tags/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tag = await _context.Tags
            .FirstOrDefaultAsync(m => m.Id == id);
        if (tag == null)
        {
            return NotFound();
        }

        return View(tag);
    }

    // GET: Dashboard/Tags/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Dashboard/Tags/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Tag tag)
    {
        if (ModelState.IsValid)
        {
            tag.Id = Guid.CreateVersion7(TimeProvider.System.GetLocalNow()).ToString();
            tag.CreatedOn = TimeProvider.System.GetLocalNow();
            _context.Add(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(tag);
    }

    // GET: Dashboard/Tags/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
        {
            return NotFound();
        }
        return View(tag);
    }

    // POST: Dashboard/Tags/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("Name,Id,IsDeleted,CreatedOn,ModifiedOn,DeletedOn")] Tag tag)
    {
        if (id != tag.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                tag.ModifiedOn = TimeProvider.System.GetLocalNow();
                _context.Update(tag);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(tag.Id))
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
        return View(tag);
    }

    // GET: Dashboard/Tags/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tag = await _context.Tags
            .FirstOrDefaultAsync(m => m.Id == id);
        if (tag == null)
        {
            return NotFound();
        }

        return View(tag);
    }

    // POST: Dashboard/Tags/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag != null)
        {
            tag.DeletedOn = TimeProvider.System.GetLocalNow();
            tag.IsDeleted = true;
            _context.Tags.Update(tag);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TagExists(string id)
    {
        return _context.Tags.Any(e => e.Id == id);
    }
}
