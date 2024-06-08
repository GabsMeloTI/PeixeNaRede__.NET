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
    public class PescariaController : Controller
    {
        private readonly Contexto _context;

        public PescariaController(Contexto context)
        {
            _context = context;
        }

        // GET: Pescaria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pescaria.ToListAsync());
        }

        // GET: Pescaria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pescaria = await _context.Pescaria
                .FirstOrDefaultAsync(m => m.CdPescaria == id);
            if (pescaria == null)
            {
                return NotFound();
            }

            return View(pescaria);
        }

        // GET: Pescaria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pescaria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdPescaria,DtPescaria,DsLocalizacao,DsCondicoesClimaticas,TpPesca,DsMetodoPesca,DsDetalhes")] Pescaria pescaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pescaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pescaria);
        }

        // GET: Pescaria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pescaria = await _context.Pescaria.FindAsync(id);
            if (pescaria == null)
            {
                return NotFound();
            }
            return View(pescaria);
        }

        // POST: Pescaria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CdPescaria,DtPescaria,DsLocalizacao,DsCondicoesClimaticas,TpPesca,DsMetodoPesca,DsDetalhes")] Pescaria pescaria)
        {
            if (id != pescaria.CdPescaria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pescaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PescariaExists(pescaria.CdPescaria))
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
            return View(pescaria);
        }

        // GET: Pescaria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pescaria = await _context.Pescaria
                .FirstOrDefaultAsync(m => m.CdPescaria == id);
            if (pescaria == null)
            {
                return NotFound();
            }

            return View(pescaria);
        }

        // POST: Pescaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pescaria = await _context.Pescaria.FindAsync(id);
            if (pescaria != null)
            {
                _context.Pescaria.Remove(pescaria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PescariaExists(int id)
        {
            return _context.Pescaria.Any(e => e.CdPescaria == id);
        }
    }
}
