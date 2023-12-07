using BackendTiendaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendTiendaVirtual.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{/*
    private readonly TiendaContext _dbContext;
    private readonly DbSet<Producto> productos;

    public ProductoController(TiendaContext dbContext)
    {
        _dbContext = dbContext;
        productos = _dbContext.Productos;
    }

    //GET: api/productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
    {
        if(productos == null)
        {
            return NotFound();
        }
        return await productos.ToListAsync();
    }

    //GET: api/productos/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(int id)
    {
        if (productos == null)
        {
            return NotFound();
        }
        var prod = await productos.FindAsync(id);

        if(prod == null)
        {
            return NotFound();
        }

        return prod;
    }

    //POST: api/productos
    [HttpPost]
    public async Task<ActionResult<Producto>> PostProducto(Producto prod)
    {
        productos.Add(prod);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductos), new { id = prod.Id}, prod);
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
    

    */
}
