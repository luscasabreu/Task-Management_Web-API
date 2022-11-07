using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Transactions;

namespace GestaoDeTarefas.PaginationService
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage{ get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool TemPaginaAnterior => CurrentPage > 1;
        public bool TemProximaPagina => CurrentPage < TotalPages;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            count = TotalCount;
            pageSize = PageSize;
            pageNumber = CurrentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public async static Task <PagedList<T>> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items =  await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(); 

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
