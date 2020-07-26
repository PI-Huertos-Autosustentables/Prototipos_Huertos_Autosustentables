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
    public class CultivosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CultivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cultivoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cultivos.ToListAsync());
        }

        // GET: Cultivoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultivo = await _context.Cultivos
                .FirstOrDefaultAsync(m => m.IdCultivo == id);
            if (cultivo == null)
            {
                return NotFound();
            }

            return View(cultivo);
        }

        // GET: Cultivoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cultivoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCultivo,IdTipoCultivos,IdRegiones,NombreCultivos,IntroduccionCultivos,CuerpoCultivos,Recomendaciones")] Cultivo cultivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cultivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cultivo);
        }

        // GET: Cultivoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultivo = await _context.Cultivos.FindAsync(id);
            if (cultivo == null)
            {
                return NotFound();
            }
            return View(cultivo);
        }

        // POST: Cultivoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCultivo,IdTipoCultivos,IdRegiones,NombreCultivos,IntroduccionCultivos,CuerpoCultivos,Recomendaciones")] Cultivo cultivo)
        {
            if (id != cultivo.IdCultivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cultivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CultivoExists(cultivo.IdCultivo))
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
            return View(cultivo);
        }

        // GET: Cultivoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultivo = await _context.Cultivos
                .FirstOrDefaultAsync(m => m.IdCultivo == id);
            if (cultivo == null)
            {
                return NotFound();
            }

            return View(cultivo);
        }

        // POST: Cultivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cultivo = await _context.Cultivos.FindAsync(id);
            _context.Cultivos.Remove(cultivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CultivoExists(int id)
        {
            return _context.Cultivos.Any(e => e.IdCultivo == id);
        }
    }
}
