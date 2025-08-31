using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alquiler_Vehiculos.Data;
using Alquiler_Vehiculos.Models.ViewModel;

namespace Alquiler_Vehiculos.Controllers
{
    public class DashboardViewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardViewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DashboardViews
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dashboards.ToListAsync());
        }

        // GET: DashboardViews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashboardViewModel = await _context.Dashboards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dashboardViewModel == null)
            {
                return NotFound();
            }

            return View(dashboardViewModel);
        }

        // GET: DashboardViews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DashboardViews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Clientes,Vehiculos,Numero_Alquiler,Total_Alquilados,Id,Create_At,Update_At,isDelete")] DashboardViewModel dashboardViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dashboardViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dashboardViewModel);
        }

        // GET: DashboardViews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashboardViewModel = await _context.Dashboards.FindAsync(id);
            if (dashboardViewModel == null)
            {
                return NotFound();
            }
            return View(dashboardViewModel);
        }

        // POST: DashboardViews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Clientes,Vehiculos,Numero_Alquiler,Total_Alquilados,Id,Create_At,Update_At,isDelete")] DashboardViewModel dashboardViewModel)
        {
            if (id != dashboardViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dashboardViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DashboardViewModelExists(dashboardViewModel.Id))
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
            return View(dashboardViewModel);
        }

        // GET: DashboardViews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashboardViewModel = await _context.Dashboards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dashboardViewModel == null)
            {
                return NotFound();
            }

            return View(dashboardViewModel);
        }

        // POST: DashboardViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dashboardViewModel = await _context.Dashboards.FindAsync(id);
            if (dashboardViewModel != null)
            {
                _context.Dashboards.Remove(dashboardViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DashboardViewModelExists(int id)
        {
            return _context.Dashboards.Any(e => e.Id == id);
        }
    }
}
