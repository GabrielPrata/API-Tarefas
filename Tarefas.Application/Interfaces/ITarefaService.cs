using System;
using System.Collections.Generic;
using Tarefas.Application.DTO;

namespace Tarefas.Application.Interfaces
{
    public interface ITarefaService
    {
        Task SaveNewTarefa(TarefaDTO tarefaData);
        Task<List<TarefaDTO>> GetAllTarefas();
    }
}
