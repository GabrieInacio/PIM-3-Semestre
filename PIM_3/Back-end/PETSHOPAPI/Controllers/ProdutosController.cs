using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PETSHOPAPI.data;
using PETSHOPAPI.models;
using PETSHOPAPI.Models;

namespace PETSHOPAPI.Controllers
{
    [ApiController]

    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly PetshopContext _context;

        public ProdutosController(
            PetshopContext context
        )
        {
            _context = context;
        }

        // =========================
        // LISTAR PRODUTOS
        // =========================

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            return await _context.Produtos.ToListAsync();
        }

        // =========================
        // CADASTRAR PRODUTO
        // =========================

        [HttpPost]
        public async Task<ActionResult> Post(
            Produto produto
        )
        {
            _context.Produtos.Add(produto);

            await _context.SaveChangesAsync();

            return Ok(produto);
        }

        // =========================
        // BUSCAR PRODUTO POR ID
        // =========================

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetById(
            int id
        )
        {
            var produto =
                await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // =========================
        // EDITAR PRODUTO
        // =========================

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(
            int id,
            Produto produto
        )
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State =
                EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // =========================
        // EXCLUIR PRODUTO
        // =========================

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(
            int id
        )
        {
            var produto =
                await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}