using ApiVentas.Data;
using ApiVentas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiVentas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly DbContextAPI _context;

        public ComprasController(DbContextAPI context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> GetCompras()
        {
            var compras = await _context.Compras
                .Include(c => c.RefDireccion)
                .Include(c => c.RefTarjeta)
                .Include(c => c.RefDetalleCompra)
                .ToListAsync();

            return Ok(compras);
        }

        // GET: api/Compras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> GetCompra(int id)
        {
            var compra = await _context.Compras
                .Include(c => c.RefDireccion)
                .Include(c => c.RefTarjeta)
                .Include(c => c.RefDetalleCompra)
                .FirstOrDefaultAsync(c => c.IdCompra == id);

            if (compra == null)
            {
                return NotFound();
            }

            return Ok(compra);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCompra([FromBody] Compra compra)
        {
            if (compra == null)
            {
                return BadRequest();
            }

            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();

            return Ok(compra);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompra(int id, Compra compra)
        {
            if (id != compra.IdCompra)
            {
                return BadRequest();
            }

            _context.Entry(compra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(id))
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

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }

            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompraExists(int id)
        {
            return _context.Compras.Any(e => e.IdCompra == id);
        }

      
    }
}