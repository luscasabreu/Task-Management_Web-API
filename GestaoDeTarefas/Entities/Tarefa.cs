using System.ComponentModel.DataAnnotations;

namespace GestaoDeTarefas.Entities
{
    public class Tarefa
    {
        [Display(Name = "Cod_Tarefa")]
        public int TarefaId { get; set; }

        [Required]
        [StringLength(80)]
        public string? Titulo { get; set; }

        [StringLength(300)]
        public string? Descricao { get; set; }
        [Required]
        public bool Conclusao { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categorias { get; set; }
    }
}
