using BackendTiendaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendTiendaVirtual.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonaController : ControllerBase
{
    private readonly TiendaContext _dbContext;
    private readonly DbSet<Persona> personas;

    public PersonaController(TiendaContext dbContext)
    {
        _dbContext = dbContext;
        personas = _dbContext.Personas;
    }

    //GET: api/personas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Persona>>> GetPersona()
    {
        if(personas == null)
        {
            return NotFound();
        }
        return await personas.ToListAsync();
    }

    //GET: api/personas/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Persona>> GetPersona(int id)
    {
        if (personas == null)
        {
            return NotFound();
        }
        var persona = await personas.FindAsync(id);

        if(persona == null)
        {
            return NotFound();
        }

        return persona;
    }

    //POST: api/personas
    [HttpPost]
    public async Task<ActionResult<Persona>> PostPersona(Persona persona)
    {
        personas.Add(persona);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPersona), new { id = persona.Id}, persona);
    }

    //PUT: api/personas/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPersona(int id, Persona persona)
    {
        if(id != persona.Id)
        {
            return BadRequest();
        }

        _dbContext.Entry(persona).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException)
        {
            if (!ExistePersona(id))
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

    //DELETE: api/personas
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersona(int id)
    {
        var persona = await personas.FindAsync(id);

        if(persona == null)
        {
            return NotFound();
        }

        persona.Estado = false;

        _dbContext.Entry(persona).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ExistePersona(id))
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

    private bool ExistePersona(int id)
    {
        return personas.Any(c => c.Id == id);
    }

}
