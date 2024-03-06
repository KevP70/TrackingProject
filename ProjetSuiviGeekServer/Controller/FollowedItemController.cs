using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetSuiviGeek.Data;
using ProjetSuiviGeek.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetSuiviGeek.Controllers
{
    public class FollowedItemController : Controller
    {
        private readonly FollowedDbContext _context;

        public FollowedItemController(FollowedDbContext context)
        {
            _context = context;
        }

        // GET: FollowedItem
        public async Task<IActionResult> Index()
        {
            return View(await _context.FollowedItem.ToListAsync());
        }

        // GET: FollowedItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followedItem = await _context.FollowedItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (followedItem == null)
            {
                return NotFound();
            }

            return View(followedItem);
        }

        // GET: FollowedItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FollowedItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Type,BeFollowed,StartDate,EndDate,Rate,Comment")] FollowedItem followedItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(followedItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(followedItem);
        }

        // GET: FollowedItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followedItem = await _context.FollowedItem.FindAsync(id);
            if (followedItem == null)
            {
                return NotFound();
            }
            return View(followedItem);
        }

        // POST: FollowedItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Type,BeFollowed,StartDate,EndDate,Rate,Comment")] FollowedItem followedItem)
        {
            if (id != followedItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(followedItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FollowedItemExists(followedItem.Id))
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
            return View(followedItem);
        }

        // GET: FollowedItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followedItem = await _context.FollowedItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (followedItem == null)
            {
                return NotFound();
            }

            return View(followedItem);
        }

        // POST: FollowedItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var followedItem = await _context.FollowedItem.FindAsync(id);
            _context.FollowedItem.Remove(followedItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FollowedItemExists(int id)
        {
            return _context.FollowedItem.Any(e => e.Id == id);
        }
    }
}
