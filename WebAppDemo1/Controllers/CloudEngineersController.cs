using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppDemo1.Data;
using WebAppDemo1.Models;

namespace WebAppDemo1.Controllers
{
    public class CloudEngineersController : Controller
    {
        private readonly WebAppDemo1Context _context;

        public CloudEngineersController(WebAppDemo1Context context)
        {
            _context = context;
        }

        // GET: CloudEngineers
        public async Task<IActionResult> Index()
        {
            return View(await _context.CloudEngineer.ToListAsync());
        }

        // GET: CloudEngineers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloudEngineer = await _context.CloudEngineer
                .FirstOrDefaultAsync(m => m.CEID == id);
            if (cloudEngineer == null)
            {
                return NotFound();
            }

            return View(cloudEngineer);
        }

        // GET: CloudEngineers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CloudEngineers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CEID,CEName,CELocation")] CloudEngineer cloudEngineer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cloudEngineer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cloudEngineer);
        }

        // GET: CloudEngineers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloudEngineer = await _context.CloudEngineer.FindAsync(id);
            if (cloudEngineer == null)
            {
                return NotFound();
            }
            return View(cloudEngineer);
        }

        // POST: CloudEngineers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CEID,CEName,CELocation")] CloudEngineer cloudEngineer)
        {
            if (id != cloudEngineer.CEID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cloudEngineer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CloudEngineerExists(cloudEngineer.CEID))
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
            return View(cloudEngineer);
        }

        // GET: CloudEngineers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloudEngineer = await _context.CloudEngineer
                .FirstOrDefaultAsync(m => m.CEID == id);
            if (cloudEngineer == null)
            {
                return NotFound();
            }

            return View(cloudEngineer);
        }

        // POST: CloudEngineers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cloudEngineer = await _context.CloudEngineer.FindAsync(id);
            _context.CloudEngineer.Remove(cloudEngineer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CloudEngineerExists(int id)
        {
            return _context.CloudEngineer.Any(e => e.CEID == id);
        }
    }
}
