using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apartamentos.Modelo;

[ApiController]
[Route("api/[controller]")]
public class ContratoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ContratoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Método GET: Obtener todos los registros de la tabla contratos
    [HttpGet]
    public async Task<IActionResult> GetContratos()
    {
        var contratos = await _context.contrato.ToListAsync();
        return Ok(contratos);
    }

    // Método POST: Crear un nuevo registro en la tabla contratos
    [HttpPost]
    public async Task<IActionResult> CreateContratos(Contrato contratos)
    {
        _context.contrato.Add(contratos);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetContratos), new { id = contratos.idcontrato }, contratos);
    }

    // Método PUT: Actualizar un registro existente en la tabla contratos
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContratos(int id, Contrato contratos)
    {
        if (id != contratos.idcontrato)
        {
            return BadRequest();
        }

        _context.Entry(contratos).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.contrato.Any(a => a.idcontrato == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // Método DELETE: Eliminar un registro por su ID en la tabla aptos
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContratos(int id)
    {
        var contratos = await _context.contrato.FindAsync(id);
        if (contratos == null)
        {
            return NotFound();
        }

        _context.contrato.Remove(contratos);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
