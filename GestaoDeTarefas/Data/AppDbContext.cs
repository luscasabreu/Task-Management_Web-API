using GestaoDeTarefas.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeTarefas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        DbSet<Tarefa>? Tarefas { get; set; }
        DbSet<Categoria>? Categorias { get; set; }
    }
}
