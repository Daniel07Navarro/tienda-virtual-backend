using BackendTiendaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendTiendaVirtual.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly TiendaContext _dbContext;
    private readonly DbSet<Categoria> categorias;

    public CategoriaController(TiendaContext dbContext)
    {
        _dbContext = dbContext;
        categorias = _dbContext.Categorias;
    }

    //GET: api/categorias
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
    {
        if(categorias == null)
        {
            return NotFound();
        }
        return await categorias.ToListAsync();
    }

    //GET: api/categorias/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> GetCategoria(int id)
    {
        if (categorias == null)
        {
            return NotFound();
        }
        var cat = await categorias.FindAsync(id);

        if(cat == null)
        {
            return NotFound();
        }

        return cat;
    }

    //POST: api/categorias
    [HttpPost]
    public async Task<ActionResult<Categoria>> PostCategoria(Categoria cat)
    {
        categorias.Add(cat);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCategoria), new { id = cat.Id}, cat);
    }

    //PUT: api/categorias/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategoria(int id, Categoria cat)
    {
        if(id != cat.Id)
        {
            return BadRequest();
        }

        _dbContext.Entry(cat).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException)
        {
            if (!ExisteCategoria(id))
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

    //DELETE: api/categorias
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoria(int id)
    {
        var cat = await categorias.FindAsync(id);

        if(cat == null)
        {
            return NotFound();
        }

        cat.Estado = false;

        _dbContext.Entry(cat).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ExisteCategoria(id))
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

    private bool ExisteCategoria(int id)
    {
        return categorias.Any(c => c.Id == id);
    }
    


}
