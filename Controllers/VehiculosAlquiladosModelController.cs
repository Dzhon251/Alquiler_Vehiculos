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
    public class VehiculosAlquiladosModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiculosAlquiladosModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VehiculosAlquiladosModel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VehiculosAlquilados.Include(v => v.AlquilerModel).Include(v => v.VehiculoModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VehiculosAlquiladosModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculosAlquiladosModel = await _context.VehiculosAlquilados
                .Include(v => v.AlquilerModel)
                .Include(v => v.VehiculoModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculosAlquiladosModel == null)
            {
                return NotFound();
            }

            return View(vehiculosAlquiladosModel);
        }

        // GET: VehiculosAlquiladosModel/Create
        public IActionResult Create()
        {
            ViewData["AlquilerModelId"] = new SelectList(_context.Alquilados, "Id", "Id");
            ViewData["VehiculosModelId"] = new SelectList(_context.Vehiculos, "Id", "Anio");
            return View();
        }

        // POST: VehiculosAlquiladosModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehiculosModelId,Nombre,Precio,Cantidad,Monto,AlquilerModelId,Id,Create_At,Update_At,isDelete")] VehiculosAlquiladosModel vehiculosAlquiladosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculosAlquiladosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlquilerModelId"] = new SelectList(_context.Alquilados, "Id", "Id", vehiculosAlquiladosModel.AlquilerModelId);
            ViewData["VehiculosModelId"] = new SelectList(_context.Vehiculos, "Id", "Anio", vehiculosAlquiladosModel.VehiculoModelId);
            return View(vehiculosAlquiladosModel);
        }

        // GET: VehiculosAlquiladosModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculosAlquiladosModel = await _context.VehiculosAlquilados.FindAsync(id);
            if (vehiculosAlquiladosModel == null)
            {
                return NotFound();
            }
            ViewData["AlquilerModelId"] = new SelectList(_context.Alquilados, "Id", "Id", vehiculosAlquiladosModel.AlquilerModelId);
            ViewData["VehiculosModelId"] = new SelectList(_context.Vehiculos, "Id", "Anio", vehiculosAlquiladosModel.VehiculoModelId);
            return View(vehiculosAlquiladosModel);
        }

        // POST: VehiculosAlquiladosModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehiculosModelId,Nombre,Precio,Cantidad,Monto,AlquilerModelId,Id,Create_At,Update_At,isDelete")] VehiculosAlquiladosModel vehiculosAlquiladosModel)
        {
            if (id != vehiculosAlquiladosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculosAlquiladosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculosAlquiladosModelExists(vehiculosAlquiladosModel.Id))
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
            ViewData["AlquilerModelId"] = new SelectList(_context.Alquilados, "Id", "Id", vehiculosAlquiladosModel.AlquilerModelId);
            ViewData["VehiculosModelId"] = new SelectList(_context.Vehiculos, "Id", "Anio", vehiculosAlquiladosModel.VehiculoModelId);
            return View(vehiculosAlquiladosModel);
        }

        // GET: VehiculosAlquiladosModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculosAlquiladosModel = await _context.VehiculosAlquilados
                .Include(v => v.AlquilerModel)
                .Include(v => v.VehiculoModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculosAlquiladosModel == null)
            {
                return NotFound();
            }

            return View(vehiculosAlquiladosModel);
        }

        // POST: VehiculosAlquiladosModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculosAlquiladosModel = await _context.VehiculosAlquilados.FindAsync(id);
            if (vehiculosAlquiladosModel != null)
            {
                _context.VehiculosAlquilados.Remove(vehiculosAlquiladosModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculosAlquiladosModelExists(int id)
        {
            return _context.VehiculosAlquilados.Any(e => e.Id == id);
        }
    }
}
