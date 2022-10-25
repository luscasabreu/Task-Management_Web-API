using GestaoDeTarefas.Data;

namespace GestaoDeTarefas.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private CategoriaRepository _categoriaRepository;
        private TarefaRepository _tarefaRepository;
        private AppDbContext _context;



        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_context);
            }
        }

        public ITarefaRepository TarefaRepository
        {
            get
            {
                return _tarefaRepository = _tarefaRepository ?? new TarefaRepository(_context);
            }
        } 

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
