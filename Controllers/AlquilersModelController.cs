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
    public class AlquilersModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlquilersModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AlquilersModel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alquilados.Include(a => a.ClientesModel).Include(a => a.VehiculoModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AlquilersModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilerModel = await _context.Alquilados
                .Include(a => a.ClientesModel)
                .Include(a => a.VehiculoModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alquilerModel == null)
            {
                return NotFound();
            }

            return View(alquilerModel);
        }

        // GET: AlquilersModel/Create
        public IActionResult Create()
        {
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes.Select(c => new { c.Id, NombreCompleto = c.Nombre + " " + c.Apellido }), "Id", "NombreCompleto");
            ViewData["VehiculoModelId"] = new SelectList(_context.Vehiculos.Select(v => new { v.Id, MarcaModelo = v.Marca + " " + v.Modelo }), "Id", "MarcaModelo");
            return View();
        }

        // POST: AlquilersModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaAlquiler,Codigo_Alquiler,Total_Alquiler,ClienteModelId,VehiculoModelId,Id,Create_At,Update_At,isDelete")] AlquilerModel alquilerModel)
        {
            if (ModelState.IsValid)
            {
                // Solo guardar el alquiler con un solo vehículo
                var vehiculo = await _context.Vehiculos.FindAsync(alquilerModel.VehiculoModelId);
                if (vehiculo != null)
                {
                    alquilerModel.Total_Alquiler = vehiculo.Precio_Diario;
                    alquilerModel.Codigo_Alquiler = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                    if (alquilerModel.FechaAlquiler == DateTime.MinValue)
                        alquilerModel.FechaAlquiler = DateTime.Now;
                }
                _context.Add(alquilerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes.Select(c => new { c.Id, NombreCompleto = c.Nombre + " " + c.Apellido }), "Id", "NombreCompleto", alquilerModel.ClienteModelId);
            ViewData["VehiculoModelId"] = new SelectList(_context.Vehiculos.Select(v => new { v.Id, MarcaModelo = v.Marca + " " + v.Modelo }), "Id", "MarcaModelo", alquilerModel.VehiculoModelId);
            return View(alquilerModel);
        }

        // GET: AlquilersModel/Edit/5
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
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes.Select(c => new { c.Id, NombreCompleto = c.Nombre + " " + c.Apellido }), "Id", "NombreCompleto", alquilerModel.ClienteModelId);
            ViewData["VehiculoModelId"] = new SelectList(_context.Vehiculos.Select(v => new { v.Id, MarcaModelo = v.Marca + " " + v.Modelo }), "Id", "MarcaModelo", alquilerModel.VehiculoModelId);
            return View(alquilerModel);
        }

        // POST: AlquilersModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FechaAlquiler,Codigo_Alquiler,Total_Alquiler,ClienteModelId,VehiculoModelId,Id,Create_At,Update_At,isDelete")] AlquilerModel alquilerModel)
        {
            if (id != alquilerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Recalcular el total en caso de que se cambie el vehículo
                    var vehiculo = await _context.Vehiculos.FindAsync(alquilerModel.VehiculoModelId);
                    if (vehiculo != null)
                    {
                        alquilerModel.Total_Alquiler = vehiculo.Precio_Diario;
                    }

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
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes.Select(c => new { c.Id, NombreCompleto = c.Nombre + " " + c.Apellido }), "Id", "NombreCompleto", alquilerModel.ClienteModelId);
            ViewData["VehiculoModelId"] = new SelectList(_context.Vehiculos.Select(v => new { v.Id, MarcaModelo = v.Marca + " " + v.Modelo }), "Id", "MarcaModelo", alquilerModel.VehiculoModelId);
            return View(alquilerModel);
        }

        // GET: AlquilersModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilerModel = await _context.Alquilados
                .Include(a => a.ClientesModel)
                .Include(a => a.VehiculoModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alquilerModel == null)
            {
                return NotFound();
            }

            return View(alquilerModel);
        }

        // POST: AlquilersModel/Delete/5
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