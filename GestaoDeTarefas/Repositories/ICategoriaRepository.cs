using GestaoDeTarefas.Entities;
using GestaoDeTarefas.PaginationService;

namespace GestaoDeTarefas.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task <PagedList<Categoria>> BuscarCategorias(CategoriasParameters categoriasParameters);
    }
}
