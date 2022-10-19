using GestaoDeTarefas.Data;
using GestaoDeTarefas.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeTarefas.Controllers
{
    [Route("tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tarefa>> Buscar()
        {
            var tarefa = _context.Tarefas.ToList();

            if (tarefa is null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpGet("{id:int}", Name = "CriarTarefa")]
        public ActionResult<Tarefa> Buscar(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.TarefaId == id);

            if (id != tarefa.TarefaId)
            {
                return BadRequest();
            }

            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> Criar(Tarefa tarefa)
        {
            if (tarefa is null)
            {
                return BadRequest();
            }

            await _context.Tarefas.AddAsync(tarefa);
            _context.SaveChanges();

            return new CreatedAtRouteResult("CriarTarefa", new { id = tarefa.TarefaId, tarefa });
            return Ok(tarefa);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Tarefa> Atualizar(int id, Tarefa tarefa)
        {
            if (tarefa is null)
            {
                return BadRequest();
            }

            _context.Entry(tarefa).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(tarefa);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Tarefa> Deletar(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.TarefaId == id);

            if(tarefa is null)
            {
                return BadRequest();
            }

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();

            return Ok(tarefa);
        }


    }
}
