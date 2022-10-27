using GestaoDeTarefas.Data;
using GestaoDeTarefas.Entities;
using GestaoDeTarefas.PaginationService;
using GestaoDeTarefas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeTarefas.Controllers
{
    [Route("tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public TarefasController(IUnitOfWork context)
        {
            _uof = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tarefa>> Buscar([FromQuery]TarefasParameters tarefasParameters)
        {
            var tarefa = _uof.TarefaRepository.BuscarTarefas(tarefasParameters).ToList();

            if (tarefa is null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpGet("{id:int}", Name = "ObterTarefa")]
        public ActionResult<Tarefa> Buscar(int id)
        {
            var tarefa = _uof.TarefaRepository.Buscar().FirstOrDefault(t => t.TarefaId == id);

            if (id != tarefa.TarefaId)
            {
                return BadRequest();
            }

            return Ok(tarefa);
        }

        [HttpPost]
        public ActionResult<Tarefa> Criar(Tarefa tarefa)
        {
            if (tarefa is null)
            {
                return BadRequest();
            }

            _uof.TarefaRepository.Adicionar(tarefa);
            _uof.Salvar();

            return new CreatedAtRouteResult("ObterTarefa", new { id = tarefa.TarefaId, tarefa });
            return Ok(tarefa);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Tarefa> Atualizar(int id, Tarefa tarefa)
        {
            if (tarefa is null)
            {
                return BadRequest();
            }

            _uof.TarefaRepository.Atualizar(tarefa);
            _uof.Salvar(); ;

            return Ok(tarefa);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Tarefa> Deletar(int id)
        {
            var tarefa = _uof.TarefaRepository.Buscar().FirstOrDefault(t => t.TarefaId == id);

            if(tarefa is null)
            {
                return BadRequest();
            }

            _uof.TarefaRepository.Deletar(tarefa);
            _uof.Salvar();

            return Ok(tarefa);
        }


    }
}
