using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandBlog.Data;
using StandBlog.Models.Entities;

namespace StandBlog.Areas.Dashboard.Controllers;

[Authorize(Roles = "Admin")]
[Area("Dashboard")]
public class ContactsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ContactsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Dashboard/Contacts
    public async Task<IActionResult> Index()
    {
        return View(await _context.Contacts.ToListAsync());
    }

    // GET: Dashboard/Contacts/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contact = await _context.Contacts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }

    // GET: Dashboard/Contacts/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contact = await _context.Contacts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }

    // POST: Dashboard/Contacts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact != null)
        {
            contact.DeletedOn = TimeProvider.System.GetLocalNow();
            contact.IsDeleted = true;
            _context.Contacts.Update(contact);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
