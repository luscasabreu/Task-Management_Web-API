using GestaoDeTarefas.Data;
using GestaoDeTarefas.Entities;

namespace GestaoDeTarefas.Repositories
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
