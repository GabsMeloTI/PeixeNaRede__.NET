using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeixeNaRede.Models;

namespace PeixeNaRede.Controllers
{
    public class EncontroController : Controller
    {
        private readonly Contexto _context;

        public EncontroController(Contexto context)
        {
            _context = context;
        }

        // GET: Encontro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Encontro.ToListAsync());
        }

        // GET: Encontro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encontro = await _context.Encontro
                .FirstOrDefaultAsync(m => m.CdEncontro == id);
            if (encontro == null)
            {
                return NotFound();
            }

            return View(encontro);
        }

        // GET: Encontro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encontro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdEncontro,DtEncontro,DsLocal,DsStatus")] Encontro encontro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encontro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(encontro);
        }

        // GET: Encontro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encontro = await _context.Encontro.FindAsync(id);
            if (encontro == null)
            {
                return NotFound();
            }
            return View(encontro);
        }

        // POST: Encontro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CdEncontro,DtEncontro,DsLocal,DsStatus")] Encontro encontro)
        {
            if (id != encontro.CdEncontro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encontro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncontroExists(encontro.CdEncontro))
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
            return View(encontro);
        }

        // GET: Encontro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encontro = await _context.Encontro
                .FirstOrDefaultAsync(m => m.CdEncontro == id);
            if (encontro == null)
            {
                return NotFound();
            }

            return View(encontro);
        }

        // POST: Encontro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encontro = await _context.Encontro.FindAsync(id);
            if (encontro != null)
            {
                _context.Encontro.Remove(encontro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncontroExists(int id)
        {
            return _context.Encontro.Any(e => e.CdEncontro == id);
        }
    }
}
