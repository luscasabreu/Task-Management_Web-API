using GestaoDeTarefas.Entities;
using GestaoDeTarefas.PaginationService;

namespace GestaoDeTarefas.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        PagedList<Categoria> BuscarCategorias(CategoriasParameters categoriasParameters);
    }
}
