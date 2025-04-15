using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apartamentos.Modelo;

[ApiController]
[Route("api/[controller]")]


    public class PersonalController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método GET: Obtener todos los registros de la tabla personal
        [HttpGet]
        public async Task<IActionResult> GetPersonal()
        {
            var personal = await _context.personal.ToListAsync();
            return Ok(personal);
        }

        // Método POST: Crear un nuevo registro en la tabla personal
        [HttpPost]
        public async Task<IActionResult> CreatePersonal(Personal personal)
        {
            _context.personal.Add(personal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPersonal), new { id = personal.idpersonal }, personal);
        }

        // Método PUT: Actualizar un registro existente en la tabla personal
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonal(int id, Personal personal)
        {
            if (id != personal.idpersonal)
            {
                return BadRequest();
            }

            _context.Entry(personal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.personal.Any(a => a.idpersonal == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // Método DELETE: Eliminar un registro por su ID en la tabla personal
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonal(int id)
        {
            var personal = await _context.personal.FindAsync(id);
            if (personal == null)
            {
                return NotFound();
            }

            _context.personal.Remove(personal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

