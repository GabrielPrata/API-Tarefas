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
            try
            {
                await _tarefaService.SaveNewTarefa(tarefaDTO);
                return Ok(new { message = "Tarefa criada com sucesso!" });
            }
            catch (JsonReaderException ex)
            {
                return BadRequest(new { message = "Erro na leitura do JSON. Verifique o formato do arquivo.", detalhes = ex.Message });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = "Erro de validação: ", detalhes = ex.Message });
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro com o banco de dados.", detalhes = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro inesperado.", detalhes = ex.Message });
            }
        }

    }
}