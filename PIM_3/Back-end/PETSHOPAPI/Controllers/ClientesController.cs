using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PETSHOPAPI.data;
using PETSHOPAPI.models;
using PETSHOPAPI.Models;

namespace PETSHOPAPI.Controllers
{
    [ApiController]

    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly PetshopContext _context;

        public ClientesController(
            PetshopContext context
        )
        {
            _context = context;
        }

        // =========================
        // LISTAR CLIENTES
        // =========================

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            return await _context.Clientes.ToListAsync();
        }

        // =========================
        // CADASTRAR CLIENTE
        // =========================

        [HttpPost]
        public async Task<ActionResult> Post(
            Cliente cliente
        )
        {
            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();

            return Ok(cliente);
        }

        // =========================
        // BUSCAR CLIENTE POR ID
        // =========================

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(
            int id
        )
        {
            var cliente =
                await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // =========================
        // EDITAR CLIENTE
        // =========================

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(
            int id,
            Cliente cliente
        )
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State =
                EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // =========================
        // EXCLUIR CLIENTE
        // =========================

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(
            int id
        )
        {
            var cliente =
                await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}