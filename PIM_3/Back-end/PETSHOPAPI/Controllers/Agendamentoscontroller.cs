using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PETSHOPAPI.data;
using PETSHOPAPI.models;

namespace PETSHOPAPI.Controllers
{
    [ApiController]
    [Route("api/agendamentos")]
    public class AgendamentosController : ControllerBase
    {
        private readonly PetshopContext _context;

        public AgendamentosController(PetshopContext context)
        {
            _context = context;
        }

        //  LISTAR TODOS OS AGENDAMENTOS
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var agendamentos = await _context.Agendamentos.ToListAsync();
            return Ok(agendamentos);
        }

        // CRIAR AGENDAMENTO
        [HttpPost]
        public async Task<IActionResult> Post(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();

            return Ok(agendamento);
        }

        //  BUSCAR POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);

            if (agendamento == null)
                return NotFound("Agendamento não encontrado");

            return Ok(agendamento);
        }

        //  DELETAR
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);

            if (agendamento == null)
                return NotFound("Agendamento não encontrado");

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();

            return Ok("Deletado com sucesso");
        }

        //  ATUALIZAR
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Agendamento updated)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);

            if (agendamento == null)
                return NotFound("Agendamento não encontrado");

            agendamento.NomePet = updated.NomePet;
            agendamento.Servico = updated.Servico;
            agendamento.DataHora = updated.DataHora;

            await _context.SaveChangesAsync();

            return Ok(agendamento);
        }
    }
}