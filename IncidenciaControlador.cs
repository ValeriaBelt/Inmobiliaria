using Apartamentos.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

    public class IncidenciaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IncidenciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método GET: Obtener todos los registros de la tabla incidencias
        [HttpGet]
        public async Task<IActionResult> GetIncidencia()
        {
            var incidencias = await _context.incidencias.ToListAsync();
            return Ok(incidencias);
        }

        // Método POST: Crear un nuevo registro en la tabla incidencias
        [HttpPost]
        public async Task<IActionResult> CreateIncidencia(Incidencia incidencias)
        {
            _context.incidencias.Add(incidencias);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetIncidencia), new { id = incidencias.idincidencia }, incidencias);
        }

        // Método PUT: Actualizar un registro existente en la tabla incidencias
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncidencia(int id, Incidencia incidencias)
        {
            if (id != incidencias.idincidencia)
            {
                return BadRequest();
            }

            _context.Entry(incidencias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.incidencias.Any(a => a.idincidencia == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // Método DELETE: Eliminar un registro por su ID en la tabla incidencias
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidencia(int id)
        {
            var incidencias = await _context.incidencias.FindAsync(id);
            if (incidencias == null)
            {
                return NotFound();
            }

            _context.incidencias.Remove(incidencias);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

