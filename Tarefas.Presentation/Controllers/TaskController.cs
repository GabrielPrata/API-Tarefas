using Microsoft.AspNetCore.Mvc;
using Tarefas.Application.Services;
using Tarefas.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using API_Tarefas.Utils;

namespace API_Tarefas.Controllers
{
    [ApiController]
    [Route("/api/Tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(IConfiguration configuration)
        {
            _taskService = new TaskService(ApiUtils.GetConnectionString(configuration));
        }

        [HttpPost]
        [Route("SaveNewTask")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveNewTask([FromBody] TaskDTO taskDTO)
        {
            await _taskService.SaveNewTask(taskDTO);
            return Ok(new { message = "Tarefa criada com sucesso!" });

        }

        [HttpGet]
        [Route("GetAllTasks")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllTasks()
        {
            return Ok(await _taskService.GetAllTasks());

        }

        [HttpGet]
        [Route("GetTaskById/{taskId:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTaskById([FromRoute] int taskId)
        {
            var tarefa = await _taskService.GetTaskById(taskId);

            //Por se tratar de um GET optei por usar o No Content em vez do Not Found
            if(tarefa == null)
            {
                return NoContent();
            }

            return Ok(tarefa);
        }

        [HttpDelete]
        [Route("DeleteTask/{taskId:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteTask([FromRoute] int taskId)
        {

            if(await _taskService.DeleteTask(taskId) == 1)
            {
                return Ok(new { message = $"Tarefa ID: {taskId} deletada com sucesso!" });
            }

            return NotFound(new { message = $"ID: {taskId} não encontrado no banco de dados!" });
        }


        //Como não havia nada descrito no teste, parti do suposto que apenas o status da tarefa deverie ser atualizado.
        [HttpPut]
        [Route("UpdateTask")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateTask([FromBody] TaskDTO taskDTO)
        {
            if(await _taskService.UpdateTask(taskDTO) == 1)
            {
                return Ok(new { message = $"Tarefa ID: {taskDTO.Id} alterada com sucesso!" });
            }

            return NotFound(new { message = $"ID: {taskDTO.Id} não encontrado no banco de dados!" });
        }

    }
}