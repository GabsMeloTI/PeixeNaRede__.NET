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
    public class CapturaController : Controller
    {
        private readonly Contexto _context;

        public CapturaController(Contexto context)
        {
            _context = context;
        }

        // GET: Captura
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Captura.Include(c => c.Especie).Include(c => c.Pescaria);
            return View(await contexto.ToListAsync());
        }

        // GET: Captura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var captura = await _context.Captura
                .Include(c => c.Especie)
                .Include(c => c.Pescaria)
                .FirstOrDefaultAsync(m => m.CdCaptura == id);
            if (captura == null)
            {
                return NotFound();
            }

            return View(captura);
        }

        // GET: Captura/Create
        public IActionResult Create()
        {
            ViewData["CdEspecie"] = new SelectList(_context.Especie, "CdEspecie", "CdEspecie");
            ViewData["CdPescaria"] = new SelectList(_context.Pescaria, "CdPescaria", "CdPescaria");
            return View();
        }

        // POST: Captura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdCaptura,DsQuantidade,DsPeso,DsFoto,CdEspecie,CdPescaria")] Captura captura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(captura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CdEspecie"] = new SelectList(_context.Especie, "CdEspecie", "CdEspecie", captura.CdEspecie);
            ViewData["CdPescaria"] = new SelectList(_context.Pescaria, "CdPescaria", "CdPescaria", captura.CdPescaria);
            return View(captura);
        }

        // GET: Captura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var captura = await _context.Captura.FindAsync(id);
            if (captura == null)
            {
                return NotFound();
            }
            ViewData["CdEspecie"] = new SelectList(_context.Especie, "CdEspecie", "CdEspecie", captura.CdEspecie);
            ViewData["CdPescaria"] = new SelectList(_context.Pescaria, "CdPescaria", "CdPescaria", captura.CdPescaria);
            return View(captura);
        }

        // POST: Captura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CdCaptura,DsQuantidade,DsPeso,DsFoto,CdEspecie,CdPescaria")] Captura captura)
        {
            if (id != captura.CdCaptura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(captura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapturaExists(captura.CdCaptura))
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
            ViewData["CdEspecie"] = new SelectList(_context.Especie, "CdEspecie", "CdEspecie", captura.CdEspecie);
            ViewData["CdPescaria"] = new SelectList(_context.Pescaria, "CdPescaria", "CdPescaria", captura.CdPescaria);
            return View(captura);
        }

        // GET: Captura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var captura = await _context.Captura
                .Include(c => c.Especie)
                .Include(c => c.Pescaria)
                .FirstOrDefaultAsync(m => m.CdCaptura == id);
            if (captura == null)
            {
                return NotFound();
            }

            return View(captura);
        }

        // POST: Captura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var captura = await _context.Captura.FindAsync(id);
            if (captura != null)
            {
                _context.Captura.Remove(captura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CapturaExists(int id)
        {
            return _context.Captura.Any(e => e.CdCaptura == id);
        }
    }
}
