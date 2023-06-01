using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using espverbs.Domain.Words.Verbs.Mutations;
using espverbs.Server.DataContext;

namespace Server.Controllers
{
    public class RegularVerbsMutationsController : Controller
    {
        private readonly EspverbsContext _context;

        public RegularVerbsMutationsController(EspverbsContext context)
        {
            _context = context;
        }

        // GET: RegularVerbsMutations
        public async Task<IActionResult> Index()
        {
            var espverbsContext = _context.RegularVerbsMutations.Include(r => r.Tense);
            return View(await espverbsContext.ToListAsync());
        }

        // GET: RegularVerbsMutations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegularVerbsMutations == null)
            {
                return NotFound();
            }

            var regularVerbsMutation = await _context.RegularVerbsMutations
                .Include(r => r.Tense)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regularVerbsMutation == null)
            {
                return NotFound();
            }

            return View(regularVerbsMutation);
        }

        // GET: RegularVerbsMutations/Create
        public IActionResult Create()
        {
            ViewData["TenseId"] = new SelectList(_context.Tenses, "Id", "Description");
            return View();
        }

        // POST: RegularVerbsMutations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Prefix,Ending,Id,PronounForm,VerbConjugationType,TenseId")] RegularVerbsMutation regularVerbsMutation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regularVerbsMutation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenseId"] = new SelectList(_context.Tenses, "Id", "Description", regularVerbsMutation.TenseId);
            return View(regularVerbsMutation);
        }

        // GET: RegularVerbsMutations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegularVerbsMutations == null)
            {
                return NotFound();
            }

            var regularVerbsMutation = await _context.RegularVerbsMutations.FindAsync(id);
            if (regularVerbsMutation == null)
            {
                return NotFound();
            }
            ViewData["TenseId"] = new SelectList(_context.Tenses, "Id", "Description", regularVerbsMutation.TenseId);
            return View(regularVerbsMutation);
        }

        // POST: RegularVerbsMutations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Prefix,Ending,Id,PronounForm,VerbConjugationType,TenseId")] RegularVerbsMutation regularVerbsMutation)
        {
            if (id != regularVerbsMutation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regularVerbsMutation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegularVerbsMutationExists(regularVerbsMutation.Id))
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
            ViewData["TenseId"] = new SelectList(_context.Tenses, "Id", "Description", regularVerbsMutation.TenseId);
            return View(regularVerbsMutation);
        }

        // GET: RegularVerbsMutations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegularVerbsMutations == null)
            {
                return NotFound();
            }

            var regularVerbsMutation = await _context.RegularVerbsMutations
                .Include(r => r.Tense)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regularVerbsMutation == null)
            {
                return NotFound();
            }

            return View(regularVerbsMutation);
        }

        // POST: RegularVerbsMutations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegularVerbsMutations == null)
            {
                return Problem("Entity set 'EspverbsContext.RegularVerbsMutations'  is null.");
            }
            var regularVerbsMutation = await _context.RegularVerbsMutations.FindAsync(id);
            if (regularVerbsMutation != null)
            {
                _context.RegularVerbsMutations.Remove(regularVerbsMutation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegularVerbsMutationExists(int id)
        {
            return (_context.RegularVerbsMutations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
