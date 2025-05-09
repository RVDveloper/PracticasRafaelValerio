using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly TodoContext _context;

    public ProductoController(TodoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> Get()
    {
        return await _context.Productos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetById(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return NotFound();
        return producto;
    }

    [HttpPost]
    public async Task<ActionResult<Producto>> Create(Producto producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
    }

   [HttpPut("{id}")]
public IActionResult PutProducto(int id, Producto producto)
{
    if (id != producto.Id)
    {
        return BadRequest("El ID de la URL no coincide con el ID del producto");
    }

    var productoExistente = _context.Productos.FirstOrDefault(p => p.Id == id);
    if (productoExistente == null)
    {
        return NotFound("Producto no encontrado");
    }

    productoExistente.Nombre = producto.Nombre;
    productoExistente.Precio = producto.Precio;
    productoExistente.Stock = producto.Stock;
    productoExistente.FechaCreacion = producto.FechaCreacion;

    try
    {
        _context.SaveChanges();
        return NoContent();
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Error al actualizar: {ex.Message}");
    }
}

[HttpDelete("{id}")]
public async Task<IActionResult> DeleteProducto(int id)
{
    var producto = await _context.Productos.FindAsync(id);
    if (producto == null)
    {
        return NotFound();
    }

    _context.Productos.Remove(producto);
    await _context.SaveChangesAsync();

    return NoContent();
}



}