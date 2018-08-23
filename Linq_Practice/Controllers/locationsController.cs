using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Linq_Practice.Data;
using Linq_Practice.Models;

namespace Linq_Practice.Controllers
{
    public class locationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public locationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: locations
        public async Task<IActionResult> Index()
        {
            return View(await _context.locations.ToListAsync());
        }

        // GET: locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.locations
                .SingleOrDefaultAsync(m => m.id == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,city,DateCreated")] location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.locations.SingleOrDefaultAsync(m => m.id == id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,city,DateCreated")] location location)
        {            
            if (id != location.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!locationExists(location.id))
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
            return View(location);
        }

        // GET: locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.locations
                .SingleOrDefaultAsync(m => m.id == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.locations.SingleOrDefaultAsync(m => m.id == id);
            _context.locations.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool locationExists(int id)
        {
            return _context.locations.Any(e => e.id == id);
        }
    }
}
