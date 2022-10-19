using GestaoDeTarefas.Data;
using GestaoDeTarefas.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeTarefas.Controllers
{
    [Route("categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Buscar()
        {
            var categoria = _context.Categorias.ToList();

            if (categoria is null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpGet("{id:int}", Name = "CriandoCategoria")]
        public async Task<ActionResult> Buscar(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Criar(Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest();
            }

            _context.Categorias.AddAsync(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("CriandoCategoria", new { id = categoria.CategoriaId }, categoria);

            return Ok(categoria);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Atualizar(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Deletar(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if(categoria is null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }

    }
}
