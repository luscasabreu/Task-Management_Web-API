using GestaoDeTarefas.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeTarefas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<Tarefa>? Tarefas { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
    }
}
