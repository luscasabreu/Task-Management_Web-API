using GestaoDeTarefas.Entities;
using GestaoDeTarefas.PaginationService;

namespace GestaoDeTarefas.Repositories
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        PagedList<Tarefa> BuscarTarefas(TarefasParameters tarefasParameters);
    }
}
