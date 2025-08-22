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
    public class VehiculosModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiculosModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VehiculosModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehiculos.ToListAsync());
        }

        // GET: VehiculosModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculoModel = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculoModel == null)
            {
                return NotFound();
            }

            return View(vehiculoModel);
        }

        // GET: VehiculosModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculosModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Marca,Modelo,Anio,Disponible,Id,Create_At,Update_At,isDelete")] VehiculoModel vehiculoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculoModel);
        }

        // GET: VehiculosModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculoModel = await _context.Vehiculos.FindAsync(id);
            if (vehiculoModel == null)
            {
                return NotFound();
            }
            return View(vehiculoModel);
        }

        // POST: VehiculosModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Marca,Modelo,Anio,Disponible,Id,Create_At,Update_At,isDelete")] VehiculoModel vehiculoModel)
        {
            if (id != vehiculoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoModelExists(vehiculoModel.Id))
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
            return View(vehiculoModel);
        }

        // GET: VehiculosModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculoModel = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculoModel == null)
            {
                return NotFound();
            }

            return View(vehiculoModel);
        }

        // POST: VehiculosModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculoModel = await _context.Vehiculos.FindAsync(id);
            if (vehiculoModel != null)
            {
                _context.Vehiculos.Remove(vehiculoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoModelExists(int id)
        {
            return _context.Vehiculos.Any(e => e.Id == id);
        }
    }
}
