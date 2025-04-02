using System;
using System.Collections.Generic;
using Tarefas.Application.DTO;
using Tarefas.Domain.Models;

namespace Tarefas.Application.Interfaces
{
    public interface ITaskService
    {
        Task SaveNewTask(TaskDTO taskDTO);
        Task<List<TaskDTO>> GetAllTasks();
        Task<TaskDTO> GetTaskById(int taskId);
        Task<int> DeleteTask(int taskId);
        Task<int> UpdateTask(TaskDTO taskDTO);
    }
}
