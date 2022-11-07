using GestaoDeTarefas.Data;
using GestaoDeTarefas.Entities;
using GestaoDeTarefas.PaginationService;

namespace GestaoDeTarefas.Repositories
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(AppDbContext context) : base(context)
        {
        }

        public  async Task <PagedList<Tarefa>> BuscarTarefas(TarefasParameters tarefasParameters)
        {
            //return _context.Tarefas
            //   .OrderBy(n => n.Conclusao)
            //   .Skip((tarefasParameters.PageNumber - 1) * tarefasParameters.PageSize)
            //   .Take(tarefasParameters.PageSize)
            //   .ToList();

            return await PagedList<Tarefa>
                .ToPagedList(Buscar().OrderBy(o => o.TarefaId), tarefasParameters.PageNumber, tarefasParameters.PageSize);
        }

    }
}
