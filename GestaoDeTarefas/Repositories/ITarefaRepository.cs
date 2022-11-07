using GestaoDeTarefas.Entities;
using GestaoDeTarefas.PaginationService;

namespace GestaoDeTarefas.Repositories
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task <PagedList<Tarefa>> BuscarTarefas(TarefasParameters tarefasParameters);
    }
}
