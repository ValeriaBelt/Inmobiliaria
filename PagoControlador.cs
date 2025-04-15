using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apartamentos.Modelo;

[ApiController]
[Route("api/[controller]")]


    public class PagoController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PagoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método GET: Obtener todos los registros de la tabla pagos
        [HttpGet]
        public async Task<IActionResult> GetPagos()
        {
            var pagos = await _context.pagos.ToListAsync();
            return Ok(pagos);
        }

        // Método POST: Crear un nuevo registro en la tabla pagos
        [HttpPost]
        public async Task<IActionResult> CreatePagos(Pago pagos)
        {
            _context.pagos.Add(pagos);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPagos), new { id = pagos.idpago }, pagos);
        }

        // Método PUT: Actualizar un registro existente en la tabla pagos
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePagos(int id, Pago pagos)
        {
            if (id != pagos.idpago)
            {
                return BadRequest();
            }

            _context.Entry(pagos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.pagos.Any(a => a.idpago == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // Método DELETE: Eliminar un registro por su ID en la tabla pagos
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagos(int id)
        {
            var pagos = await _context.pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }

            _context.pagos.Remove(pagos);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

