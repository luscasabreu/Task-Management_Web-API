namespace GestaoDeTarefas.Repositories
{
    public interface IUnitOfWork
    {
        public ICategoriaRepository CategoriaRepository { get; }
        public ITarefaRepository TarefaRepository { get; }
        Task Salvar();
    }
}
