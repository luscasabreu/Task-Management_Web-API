using GestaoDeTarefas.Data;
using GestaoDeTarefas.Entities;
using GestaoDeTarefas.PaginationService;
using GestaoDeTarefas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public async Task <ActionResult<IEnumerable<Tarefa>>> Buscar([FromQuery]TarefasParameters tarefasParameters)
        {
            var tarefa = await _uof.TarefaRepository.BuscarTarefas(tarefasParameters);

            var dados = new
            {
                tarefa.TotalCount,
                tarefa.PageSize,
                tarefa.CurrentPage,
                tarefa.TotalPages,
                tarefa.TemProximaPagina,
                tarefa.TemPaginaAnterior
            };

            Response.Headers.Add("Paginacao", JsonConvert.SerializeObject(dados));

            if (tarefa is null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpGet("{id:int}", Name = "ObterTarefa")]
        public async Task <ActionResult<Tarefa>> BuscarPorId(int id)
        {
            var tarefa = await _uof.TarefaRepository.Buscar().FirstOrDefaultAsync(t => t.TarefaId == id);

            if (id != tarefa.TarefaId)
            {
                return BadRequest();
            }

            return Ok(tarefa);
        }

        [HttpPost]
        public async Task <ActionResult<Tarefa>> Criar(Tarefa tarefa)
        {
            if (tarefa is null)
            {
                return BadRequest();
            }

            _uof.TarefaRepository.Adicionar(tarefa);
            await _uof.Salvar();

            return new CreatedAtRouteResult("ObterTarefa", new { id = tarefa.TarefaId, tarefa });
            return Ok(tarefa);
        }

        [HttpPut("{id:int}")]
        public async Task <ActionResult<Tarefa>> Atualizar(int id, Tarefa tarefa)
        {
            if (tarefa is null)
            {
                return BadRequest();
            }

            _uof.TarefaRepository.Atualizar(tarefa);
            await _uof.Salvar(); ;

            return Ok(tarefa);
        }

        [HttpDelete("{id:int}")]
        public async Task <ActionResult<Tarefa>> Deletar(int id)
        {
            var tarefa = _uof.TarefaRepository.Buscar().FirstOrDefault(t => t.TarefaId == id);

            if(tarefa is null)
            {
                return BadRequest();
            }

            _uof.TarefaRepository.Deletar(tarefa);
            await _uof.Salvar();

            return Ok(tarefa);
        }


    }
}
