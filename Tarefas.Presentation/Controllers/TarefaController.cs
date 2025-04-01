using Microsoft.AspNetCore.Mvc;
using Tarefas.Application.Services;
using Tarefas.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using API_Tarefas.Utils;
using System.Data.SqlTypes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace API_Tarefas.Controllers
{
    [ApiController]
    [Route("/api/Tarefas")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaService _tarefaService;

        public TarefaController(IConfiguration configuration)
        {
            _tarefaService = new TarefaService(ApiUtils.GetConnectionString(configuration));
        }

        [HttpPost]
        [Route("SaveNewTarefa")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveNewTarefa([FromBody] TarefaDTO tarefaDTO)
        {
            await _tarefaService.SaveNewTarefa(tarefaDTO);
            return Ok(new { message = "Tarefa criada com sucesso!" });

        }

        [HttpGet]
        [Route("GetAllTarefas")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllTarefas()
        {
            var tarefas = await _tarefaService.GetAllTarefas();
            return Ok(tarefas);

        }

        [HttpGet]
        [Route("GetTarefaById/{tarefaId:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTarefaById([FromRoute] int tarefaId)
        {
            var tarefa = await _tarefaService.GetTarefaById(tarefaId);

            if(tarefa == null)
            {
                return NoContent();
            }

            return Ok(tarefa);
        }

    }
}