using Tarefas.Application.DTO;
using Tarefas.Application.Interfaces;
using Tarefas.Application.Mappers;
using Tarefas.Domain.Models;
using Tarefas.Infraestructure;


namespace Tarefas.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskRepository _repository;
        public TaskService(string stringConnection) {
            _repository = new TaskRepository(stringConnection);
        }

        public async Task<List<TaskDTO>> GetAllTasks()
        {
            var data = await _repository.GetAllTasks();

            List<TaskDTO> tasksDTO = new List<TaskDTO>();

            foreach(TaskModel task in data)
            {
                tasksDTO.Add(TaskMapper.ToDTO(task));
            }

            return tasksDTO;
        }

        public async Task SaveNewTask(TaskDTO taskDTO)
        {
            await _repository.SaveNewTask(TaskMapper.ToModel(taskDTO));
        }

        public async Task<TaskDTO> GetTaskById(int taskId)
        {
            TaskModel data = await _repository.GetTaskById(taskId);

            if (data == null)
            {
                return null;
            }

            TaskDTO tasksDTO = TaskMapper.ToDTO(data);    

            return tasksDTO;
        }

        public async Task<int> DeleteTask(int taskId)
        {
           return await _repository.DeleteTask(taskId);
        }

        public async Task<int> UpdateTask(TaskDTO taskDTO)
        {
            return await _repository.UpdateTask(TaskMapper.ToModel(taskDTO));
        }
    }
}
