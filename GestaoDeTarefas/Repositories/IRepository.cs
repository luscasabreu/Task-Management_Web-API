using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace GestaoDeTarefas.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> Buscar();
        T Buscar(Expression<Func<T, bool>> predicate);
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Deletar(T Entity);
    }
}
