using GestaoDeTarefas.Entities;
using GestaoDeTarefas.PaginationService;
using GestaoDeTarefas.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GestaoDeTarefas.Controllers
{
    [Route("categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
    

        public CategoriasController(IUnitOfWork context)
        {
            _uof = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Buscar([FromQuery] CategoriasParameters categoriasParameters)
        {
            var categoria = _uof.CategoriaRepository.BuscarCategorias(categoriasParameters);

            var dados = new
            {
                categoria.TotalCount,
                categoria.PageSize,
                categoria.CurrentPage,
                categoria.TotalPages,
                categoria.TemProximaPagina,
                categoria.TemPaginaAnterior
            };

            Response.Headers.Add("Paginacao", JsonConvert.SerializeObject(dados));

            if (categoria is null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpGet("{id:int}", Name = "CriandoCategoria")]
        public ActionResult Buscar(int id)
        {
            var categoria = _uof.CategoriaRepository.Buscar().FirstOrDefault(c => c.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Criar(Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest();
            }

            _uof.CategoriaRepository.Adicionar(categoria);
            _uof.Salvar();

            return new CreatedAtRouteResult("CriandoCategoria", new { id = categoria.CategoriaId }, categoria);

            return Ok(categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Atualizar(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }
            _uof.CategoriaRepository.Atualizar(categoria);
            _uof.Salvar();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Deletar(int id)
        {
            var categoria = _uof.CategoriaRepository.Buscar().FirstOrDefault(c => c.CategoriaId == id);

            if(categoria is null)
            {
                return NotFound();
            }

            _uof.CategoriaRepository.Deletar(categoria);
            _uof.Salvar();

            return Ok(categoria);
        }

    }
}
