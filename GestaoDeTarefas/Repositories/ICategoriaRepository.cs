﻿using GestaoDeTarefas.Entities;

namespace GestaoDeTarefas.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> BuscarCategoriaTarefa();
    }
}