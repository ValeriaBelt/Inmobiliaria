using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apartamentos.Modelo;

[ApiController]
[Route("api/[controller]")]

 public class MantenimientoController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MantenimientoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método GET: Obtener todos los registros de la tabla mantenimientos
        [HttpGet]
        public async Task<IActionResult> GetMantenimiento()
        {
            var mantenimientos = await _context.mantenimiento.ToListAsync();
            return Ok(mantenimientos);
        }

        // Método POST: Crear un nuevo registro en la tabla mantenimiento
        [HttpPost]
        public async Task<IActionResult> CreateMantenimiento(Mantenimiento mantenimientos)
        {
            _context.mantenimiento.Add(mantenimientos);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMantenimiento), new { id = mantenimientos.idmantenimiento }, mantenimientos);
        }

        // Método PUT: Actualizar un registro existente en la tabla mantenimiento
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMantenimiento(int id, Mantenimiento mantenimientos)
        {
            if (id != mantenimientos.idmantenimiento)
            {
                return BadRequest();
            }

            _context.Entry(mantenimientos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.mantenimiento.Any(a => a.idmantenimiento == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // Método DELETE: Eliminar un registro por su ID en la tabla mantenimiento
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletMantenimento(int id)
        {
            var mantenimientos = await _context.mantenimiento.FindAsync(id);
            if (mantenimientos == null)
            {
                return NotFound();
            }

            _context.mantenimiento.Remove(mantenimientos);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

