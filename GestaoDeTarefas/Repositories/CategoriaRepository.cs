using GestaoDeTarefas.Data;
using GestaoDeTarefas.Entities;
using GestaoDeTarefas.PaginationService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeTarefas.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task <PagedList<Categoria>> BuscarCategorias(CategoriasParameters categoriasParameters)
        {
            return  await PagedList<Categoria>
                .ToPagedList(Buscar().OrderBy(o => o.CategoriaId), categoriasParameters.PageNumber, categoriasParameters.PageSize);
        }

    }
}

