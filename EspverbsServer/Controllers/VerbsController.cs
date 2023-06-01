using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using espverbs.Domain.Words.Verbs;
using espverbs.Server.DataContext;

namespace Server.Controllers
{
    public class VerbsController : Controller
    {
        private readonly EspverbsContext _context;

        public VerbsController(EspverbsContext context)
        {
            _context = context;
        }

        // GET: Verbs
        public async Task<IActionResult> Index()
        {
            return _context.Verbs != null ?
                        View(await _context.Verbs.ToListAsync()) :
                        Problem("Entity set 'EspverbsContext.Verbs'  is null.");
        }

        // GET: Verbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Verbs == null)
            {
                return NotFound();
            }

            var verb = await _context.Verbs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (verb == null)
            {
                return NotFound();
            }

            return View(verb);
        }

        // GET: Verbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Verbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Root,Ending,ConjugationType,Id,Word")] Verb verb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(verb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verb);
        }

        // GET: Verbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Verbs == null)
            {
                return NotFound();
            }

            var verb = await _context.Verbs.FindAsync(id);
            if (verb == null)
            {
                return NotFound();
            }
            return View(verb);
        }

        // POST: Verbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Root,Ending,ConjugationType,Id,Word")] Verb verb)
        {
            if (id != verb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerbExists(verb.Id))
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
            return View(verb);
        }

        // GET: Verbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Verbs == null)
            {
                return NotFound();
            }

            var verb = await _context.Verbs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (verb == null)
            {
                return NotFound();
            }

            return View(verb);
        }

        // POST: Verbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Verbs == null)
            {
                return Problem("Entity set 'EspverbsContext.Verbs'  is null.");
            }
            var verb = await _context.Verbs.FindAsync(id);
            if (verb != null)
            {
                _context.Verbs.Remove(verb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VerbExists(int id)
        {
            return (_context.Verbs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
