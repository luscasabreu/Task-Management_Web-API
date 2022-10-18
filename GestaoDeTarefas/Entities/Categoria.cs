using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeTarefas.Entities
{
    public class Categoria
    {
        public Categoria()
        {
            Tarefas = new Collection<Tarefa>();
        }
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
