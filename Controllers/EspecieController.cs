using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeixeNaRede.Models;

namespace PeixeNaRede.Controllers
{
    public class EspecieTController : Controller
    {
        private readonly Contexto _context;

        public EspecieTController(Contexto context)
        {
            _context = context;
        }

        // GET: EspecieT
        public async Task<IActionResult> Index()
        {
            return View(await _context.Especie.ToListAsync());
        }

        // GET: EspecieT/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie
                .FirstOrDefaultAsync(m => m.CdEspecie == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        // GET: EspecieT/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EspecieT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdEspecie,NmCientifico,NmPopular,DsFoto,DsDescricao")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especie);
        }

        // GET: EspecieT/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie.FindAsync(id);
            if (especie == null)
            {
                return NotFound();
            }
            return View(especie);
        }

        // POST: EspecieT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CdEspecie,NmCientifico,NmPopular,DsFoto,DsDescricao")] Especie especie)
        {
            if (id != especie.CdEspecie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecieExists(especie.CdEspecie))
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
            return View(especie);
        }

        // GET: EspecieT/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie
                .FirstOrDefaultAsync(m => m.CdEspecie == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        // POST: EspecieT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especie = await _context.Especie.FindAsync(id);
            if (especie != null)
            {
                _context.Especie.Remove(especie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecieExists(int id)
        {
            return _context.Especie.Any(e => e.CdEspecie == id);
        }
    }
}
