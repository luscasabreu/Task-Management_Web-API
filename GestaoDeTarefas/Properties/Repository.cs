using GestaoDeTarefas.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestaoDeTarefas.Properties
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public void Adicionar(T entity)
        {
            _context.Add(entity);
        }

        public void Atualizar(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity); 
        }

        public IQueryable<T> Buscar()
        {
            return _context.Set<T>().AsNoTracking();
        }


        public T Buscar(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public void Deletar(T entity)
        {
            _context.Remove(entity);
        }
    }
}
