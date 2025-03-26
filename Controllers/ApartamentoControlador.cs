using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apartamentos.Modelo;

[ApiController]
[Route("api/[controller]")]
public class AptoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AptoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Método GET: Obtener todos los registros de la tabla aptos
    [HttpGet]
    public async Task<IActionResult> GetAptos()
    {
        var aptos = await _context.apartamentos.ToListAsync();
        return Ok(aptos);
    }

    // Método POST: Crear un nuevo registro en la tabla aptos
    [HttpPost]
    public async Task<IActionResult> CreateApto(Apto apto)
    {
        _context.apartamentos.Add(apto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAptos), new { id = apto.apartamentosID }, apto);
    }

    // Método PUT: Actualizar un registro existente en la tabla aptos
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateApto(int id, Apto apto)
    {
        if (id != apto.apartamentosID)
        {
            return BadRequest();
        }

        _context.Entry(apto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.apartamentos.Any(a => a.apartamentosID == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // Método DELETE: Eliminar un registro por su ID en la tabla aptos
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApto(int id)
    {
        var apto = await _context.apartamentos.FindAsync(id);
        if (apto == null)
        {
            return NotFound();
        }

        _context.apartamentos.Remove(apto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
