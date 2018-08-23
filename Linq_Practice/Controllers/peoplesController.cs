using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Linq_Practice.Data;
using Linq_Practice.Models;
using Linq_Practice.Data.Migrations;
using Microsoft.AspNetCore.Identity;

namespace Linq_Practice.Controllers
{
    public class peoplesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;


        public peoplesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        // GET: peoples
        public async Task<IActionResult> Index()
        {     
            return View(await _context.persons.ToListAsync());            
        }

        // GET: peoples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.persons
                .SingleOrDefaultAsync(m => m.id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }
        

        // GET: peoples/Create
        public IActionResult Create()
        {
            return View();
        }          
        
        // POST: peoples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        person newperson = new person()
        {
            name = "PersonA",
            age = 33,
            City = "Boston,Ma",
            LovesToTravel = false
        };

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,age,City,LovesToTravel")] person person)
        {
            if (ModelState.IsValid)            {
                
                _context.Add(person);

                await _context.SaveChangesAsync();

                //***NEED TO GET THE LAST PERSON***

                //return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(EditLastPerson));
            }

            return View(person);
        }

        // GET: peoples/Edit/5
        public async Task<IActionResult> Edit(int? id) // Gets the person profile based on ID and posts it to: https://localhost:44347/peoples/Edit/1010. 
        //The id comes from the search bar which is the configuration in the startup: /peoples/Edit/1010
        {
            if (id == null)
            {
                return Content("FROM HTTP GET: No such person found.");
            }

            var person = await _context.persons.SingleOrDefaultAsync(m => m.id == id);

            if (person == null)
            {
                return Content("First or default for variable returned no match.");
            }
            return View(person);
        }

        public async Task<IActionResult> EditLastPerson()
        {
            var LastPerson =  _context.persons.Last();
            //_context.Update(LastPerson);

            await _context.SaveChangesAsync();

            return View(LastPerson);
        }

        // POST: peoples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,age,City,LovesToTravel")] person person) //Note: the [Bind()] is used mainly for security purposes. The Edit still works (I just deleted the Bind and the edit still works).
        {
            if (id != person.id)
            {
                return Content("MSG. FROM HTTP POST: No such person found");
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person); // <= This is responsible for updating the form AND the table with new information. If you take this out, the form will NOT update.
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!personExists(person.id))
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
            return View(person);
        }

        // GET: peoples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return Content("No person to delete");
            }

            var person = await _context.persons
                .SingleOrDefaultAsync(m => m.id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: peoples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.persons.SingleOrDefaultAsync(m => m.id == id);
            _context.persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool personExists(int id)
        {
            return _context.persons.Any(e => e.id == id);
        } 
    }
}
