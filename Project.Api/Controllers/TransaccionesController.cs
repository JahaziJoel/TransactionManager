using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Data;
using Project.Api.Models;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransaccionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaccion>>> GetAll()
        {
            return await _context.Transacciones.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Transaccion>> Create(Transaccion transaccion)
        {
            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = transaccion.Id }, transaccion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transaccion = await _context.Transacciones.FindAsync(id);
            if (transaccion == null)
                return NotFound();

            _context.Transacciones.Remove(transaccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Transaccion transaccion)
        {
            if (id != transaccion.Id)
                return BadRequest();

            var existente = await _context.Transacciones.FindAsync(id);
            if(existente is null)
                return NotFound();

            existente.Tipo = transaccion.Tipo;
            existente.Categoria = transaccion.Categoria;
            existente.Monto = transaccion.Monto;
            existente.Fecha = transaccion.Fecha;
            existente.Descripcion = transaccion.Descripcion;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
