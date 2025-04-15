using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apartamentos.Modelo;

[ApiController]
[Route("api/[controller]")]


    public class InquilinoController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InquilinoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método GET: Obtener todos los registros de la tabla inquilino
        [HttpGet]
        public async Task<IActionResult> GetInquilino()
        {
            var inquilinos = await _context.inquilino.ToListAsync();
            return Ok(inquilinos);
        }

        // Método POST: Crear un nuevo registro en la tabla inquilino
        [HttpPost]
        public async Task<IActionResult> CreateInquilino(Inquilino inquilinos)
        {
            _context.inquilino.Add(inquilinos);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInquilino), new { id = inquilinos.iddocumento }, inquilinos);
        }

        // Método PUT: Actualizar un registro existente en la tabla inquilino
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInquilino(int id, Inquilino inquilinos)
        {
            if (id != inquilinos.iddocumento)
            {
                return BadRequest();
            }

            _context.Entry(inquilinos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.inquilino.Any(a => a.iddocumento == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // Método DELETE: Eliminar un registro por su ID en la tabla inquilino
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInquilino(int id)
        {
            var inquilinos = await _context.inquilino.FindAsync(id);
            if (inquilinos == null)
            {
                return NotFound();
            }

            _context.inquilino.Remove(inquilinos);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

