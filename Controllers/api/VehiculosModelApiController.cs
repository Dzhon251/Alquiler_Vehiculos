using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alquiler_Vehiculos.Data;
using Alquiler_Vehiculos.Models.Entity;

namespace Alquiler_Vehiculos.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosModelApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VehiculosModelApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/VehiculosModelApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoModel>>> GetVehiculos()
        {
            return await _context.Vehiculos.ToListAsync();
        }

        // GET: api/VehiculosModelApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoModel>> GetVehiculoModel(int id)
        {
            var vehiculoModel = await _context.Vehiculos.FindAsync(id);

            if (vehiculoModel == null)
            {
                return NotFound();
            }

            return vehiculoModel;
        }

        // PUT: api/VehiculosModelApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculoModel(int id, VehiculoModel vehiculoModel)
        {
            if (id != vehiculoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehiculoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VehiculosModelApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehiculoModel>> PostVehiculoModel(VehiculoModel vehiculoModel)
        {
            _context.Vehiculos.Add(vehiculoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculoModel", new { id = vehiculoModel.Id }, vehiculoModel);
        }

        // DELETE: api/VehiculosModelApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculoModel(int id)
        {
            var vehiculoModel = await _context.Vehiculos.FindAsync(id);
            if (vehiculoModel == null)
            {
                return NotFound();
            }

            _context.Vehiculos.Remove(vehiculoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoModelExists(int id)
        {
            return _context.Vehiculos.Any(e => e.Id == id);
        }
    }
}
