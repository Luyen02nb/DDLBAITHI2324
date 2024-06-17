using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABC.Data;
using MVC.Models;

namespace DDLBAITHI2324.Controllers
{
    public class DDL416PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DDL416PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DDL416Person
        public async Task<IActionResult> Index()
        {
            return View(await _context.DDL416Person.ToListAsync());
        }

        // GET: DDL416Person/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dDL416Person = await _context.DDL416Person
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (dDL416Person == null)
            {
                return NotFound();
            }

            return View(dDL416Person);
        }

        // GET: DDL416Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DDL416Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FullName,Address")] DDL416Person dDL416Person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dDL416Person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dDL416Person);
        }

        // GET: DDL416Person/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dDL416Person = await _context.DDL416Person.FindAsync(id);
            if (dDL416Person == null)
            {
                return NotFound();
            }
            return View(dDL416Person);
        }

        // POST: DDL416Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonId,FullName,Address")] DDL416Person dDL416Person)
        {
            if (id != dDL416Person.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dDL416Person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DDL416PersonExists(dDL416Person.PersonId))
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
            return View(dDL416Person);
        }

        // GET: DDL416Person/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dDL416Person = await _context.DDL416Person
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (dDL416Person == null)
            {
                return NotFound();
            }

            return View(dDL416Person);
        }

        // POST: DDL416Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dDL416Person = await _context.DDL416Person.FindAsync(id);
            if (dDL416Person != null)
            {
                _context.DDL416Person.Remove(dDL416Person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DDL416PersonExists(string id)
        {
            return _context.DDL416Person.Any(e => e.PersonId == id);
        }
    }
}
