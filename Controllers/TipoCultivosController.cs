using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prototipos_Huertos_Autosustentables.Data;
using Prototipos_Huertos_Autosustentables.Models;

namespace Prototipos_Huertos_Autosustentables.Controllers
{
    public class TipoCultivosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoCultivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoCultivoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoCultivos.ToListAsync());
        }

        // GET: TipoCultivoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCultivo = await _context.TipoCultivos
                .FirstOrDefaultAsync(m => m.IdTipoCultivos == id);
            if (tipoCultivo == null)
            {
                return NotFound();
            }

            return View(tipoCultivo);
        }

        // GET: TipoCultivoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCultivoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoCultivos,NombreTipoCultivos")] TipoCultivo tipoCultivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCultivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCultivo);
        }

        // GET: TipoCultivoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCultivo = await _context.TipoCultivos.FindAsync(id);
            if (tipoCultivo == null)
            {
                return NotFound();
            }
            return View(tipoCultivo);
        }

        // POST: TipoCultivoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoCultivos,NombreTipoCultivos")] TipoCultivo tipoCultivo)
        {
            if (id != tipoCultivo.IdTipoCultivos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCultivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCultivoExists(tipoCultivo.IdTipoCultivos))
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
            return View(tipoCultivo);
        }

        // GET: TipoCultivoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCultivo = await _context.TipoCultivos
                .FirstOrDefaultAsync(m => m.IdTipoCultivos == id);
            if (tipoCultivo == null)
            {
                return NotFound();
            }

            return View(tipoCultivo);
        }

        // POST: TipoCultivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoCultivo = await _context.TipoCultivos.FindAsync(id);
            _context.TipoCultivos.Remove(tipoCultivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCultivoExists(int id)
        {
            return _context.TipoCultivos.Any(e => e.IdTipoCultivos == id);
        }
    }
}
