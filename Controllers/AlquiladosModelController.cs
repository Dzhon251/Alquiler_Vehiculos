using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alquiler_Vehiculos.Data;
using Alquiler_Vehiculos.Models.Entity;

namespace Alquiler_Vehiculos.Controllers
{
    public class AlquiladosModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlquiladosModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AlquiladosModel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alquilados.Include(a => a.ClientesModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AlquiladosModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilerModel = await _context.Alquilados
                .Include(a => a.ClientesModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alquilerModel == null)
            {
                return NotFound();
            }

            return View(alquilerModel);
        }

        // GET: AlquiladosModel/Create
        public IActionResult Create()
        {
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes, "Id", "Apellido");
            return View();
        }

        // POST: AlquiladosModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaAlquiler,Codigo_Alquiler,Total_Alquiler,ClienteModelId,Id,Create_At,Update_At,isDelete")] AlquilerModel alquilerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alquilerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes, "Id", "Apellido", alquilerModel.ClienteModelId);
            return View(alquilerModel);
        }

        // GET: AlquiladosModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilerModel = await _context.Alquilados.FindAsync(id);
            if (alquilerModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes, "Id", "Apellido", alquilerModel.ClienteModelId);
            return View(alquilerModel);
        }

        // POST: AlquiladosModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FechaAlquiler,Codigo_Alquiler,Total_Alquiler,ClienteModelId,Id,Create_At,Update_At,isDelete")] AlquilerModel alquilerModel)
        {
            if (id != alquilerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alquilerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlquilerModelExists(alquilerModel.Id))
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
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes, "Id", "Apellido", alquilerModel.ClienteModelId);
            return View(alquilerModel);
        }

        // GET: AlquiladosModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilerModel = await _context.Alquilados
                .Include(a => a.ClientesModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alquilerModel == null)
            {
                return NotFound();
            }

            return View(alquilerModel);
        }

        // POST: AlquiladosModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alquilerModel = await _context.Alquilados.FindAsync(id);
            if (alquilerModel != null)
            {
                _context.Alquilados.Remove(alquilerModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlquilerModelExists(int id)
        {
            return _context.Alquilados.Any(e => e.Id == id);
        }
    }
}
