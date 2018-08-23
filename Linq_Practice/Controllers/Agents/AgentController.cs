using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Linq_Practice.Data;
using Linq_Practice.Models.Agents;

namespace Linq_Practice.Controllers.Agents
{
    public class AgentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgentController(ApplicationDbContext context)
        {
            _context = context;
        }

        AgentInfo agent1 = new AgentInfo()
        {
            name = "Kelley",
            ImagePath = "~/images/TravelAgent.jpg",
            email = "KelleyLovesTravel@email.com"
        };

        AgentInfo agent2 = new AgentInfo()
        {
            name = "Rickie",
            ImagePath = "~/images/TravelAgent.jpg",
            email = "RickieLovesTravel@email.com"
        };

        AgentInfo agent3 = new AgentInfo()
        {
            name = "Andie",
            ImagePath = "~/images/TravelAgent.jpg",
            email = "AndieLovesTravel@email.com"
        };


        // GET: Agent
        public async Task<IActionResult> Index()
        {
            if(await _context.AgentInfo.CountAsync() <= 2)
            {               
                _context.AgentInfo.Add(agent1);
                _context.AgentInfo.Add(agent2);
                _context.AgentInfo.Add(agent3);

                //_context.SaveChanges();
            }
                        
            return View(await _context.AgentInfo.ToListAsync());
        }

        

        public async Task<IActionResult> IndexII()
        {
            bid bid1 = new bid()
            {
                AgentInfo = agent1,
                DatePosted = DateTime.Now,
                BidAmount = 3000
            };

            bid bid2 = new bid()
            {
                AgentInfo = agent3,
                DatePosted = DateTime.Now,
                BidAmount = 2900
            };

            if (await _context.bid.CountAsync() == 2)
            {
                _context.bid.Add(bid1);
                _context.bid.Add(bid2);

                //_context.SaveChanges();
            }

            return View(await _context.bid.Include(x => x.AgentInfo).ToListAsync());

        }

        // GET: Agent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentInfo = await _context.AgentInfo
                .SingleOrDefaultAsync(m => m.id == id);
            if (agentInfo == null)
            {
                return NotFound();
            }

            return View(agentInfo);
        }

        // GET: Agent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,email,ImagePath")] AgentInfo agentInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agentInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agentInfo);
        }

        // GET: Agent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentInfo = await _context.AgentInfo.SingleOrDefaultAsync(m => m.id == id);
            if (agentInfo == null)
            {
                return NotFound();
            }
            return View(agentInfo);
        }

        // POST: Agent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,email,ImagePath")] AgentInfo agentInfo)
        {
            if (id != agentInfo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agentInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentInfoExists(agentInfo.id))
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
            return View(agentInfo);
        }

        // GET: Agent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentInfo = await _context.AgentInfo
                .SingleOrDefaultAsync(m => m.id == id);
            if (agentInfo == null)
            {
                return NotFound();
            }

            return View(agentInfo);
        }

        // POST: Agent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agentInfo = await _context.AgentInfo.SingleOrDefaultAsync(m => m.id == id);
            _context.AgentInfo.Remove(agentInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentInfoExists(int id)
        {
            return _context.AgentInfo.Any(e => e.id == id);
        }
    }
}
