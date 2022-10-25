using GestaoDeTarefas.Data;
using GestaoDeTarefas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeTarefas.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        { }

        public IEnumerable<Categoria> BuscarCategoriaTarefa()
        {
            return Buscar().Include(x => x.Tarefas);
        }

    }
}

