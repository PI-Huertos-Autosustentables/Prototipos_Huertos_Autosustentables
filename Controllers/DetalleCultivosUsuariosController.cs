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
    public class DetalleCultivosUsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalleCultivosUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetalleCultivosUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetalleCultivosUsuarios.ToListAsync());
        }

        // GET: DetalleCultivosUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCultivosUsuario = await _context.DetalleCultivosUsuarios
                .FirstOrDefaultAsync(m => m.IdDetalle == id);
            if (detalleCultivosUsuario == null)
            {
                return NotFound();
            }

            return View(detalleCultivosUsuario);
        }

        // GET: DetalleCultivosUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetalleCultivosUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalle,IdCultivo,IdUsers,MetrosCuadrasDetalle,PrecioSemillasDetalle,LugarCultivoDetalle")] DetalleCultivosUsuario detalleCultivosUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleCultivosUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detalleCultivosUsuario);
        }

        // GET: DetalleCultivosUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCultivosUsuario = await _context.DetalleCultivosUsuarios.FindAsync(id);
            if (detalleCultivosUsuario == null)
            {
                return NotFound();
            }
            return View(detalleCultivosUsuario);
        }

        // POST: DetalleCultivosUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalle,IdCultivo,IdUsers,MetrosCuadrasDetalle,PrecioSemillasDetalle,LugarCultivoDetalle")] DetalleCultivosUsuario detalleCultivosUsuario)
        {
            if (id != detalleCultivosUsuario.IdDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleCultivosUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleCultivosUsuarioExists(detalleCultivosUsuario.IdDetalle))
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
            return View(detalleCultivosUsuario);
        }

        // GET: DetalleCultivosUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCultivosUsuario = await _context.DetalleCultivosUsuarios
                .FirstOrDefaultAsync(m => m.IdDetalle == id);
            if (detalleCultivosUsuario == null)
            {
                return NotFound();
            }

            return View(detalleCultivosUsuario);
        }

        // POST: DetalleCultivosUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleCultivosUsuario = await _context.DetalleCultivosUsuarios.FindAsync(id);
            _context.DetalleCultivosUsuarios.Remove(detalleCultivosUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleCultivosUsuarioExists(int id)
        {
            return _context.DetalleCultivosUsuarios.Any(e => e.IdDetalle == id);
        }
    }
}
