using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;
using StandBlog.Models.Entities;

namespace StandBlog.Areas.Dashboard.Controllers;

[Authorize(Roles = "Admin")]
[Area("Dashboard")]
public class CommentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public CommentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Dashboard/Comments
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Comments.Include(c => c.Blog);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Dashboard/Comments/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var comment = await _context.Comments
            .Include(c => c.Blog)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (comment == null)
        {
            return NotFound();
        }

        return View(comment);
    }

    // GET: Dashboard/Comments/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var comment = await _context.Comments
            .Include(c => c.Blog)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (comment == null)
        {
            return NotFound();
        }

        return View(comment);
    }

    // POST: Dashboard/Comments/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment != null)
        {
            comment.DeletedOn = TimeProvider.System.GetLocalNow();
            comment.IsDeleted = true;
            _context.Comments.Update(comment);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
