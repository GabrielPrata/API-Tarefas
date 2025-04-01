using Tarefas.Application.DTO;
using Tarefas.Application.Interfaces;
using Tarefas.Application.Mappers;
using Tarefas.Domain.Models;
using Tarefas.Infraestructure;


namespace Tarefas.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly TarefaRepository _repository;
        public TarefaService(string stringConnection) {
            _repository = new TarefaRepository(stringConnection);
        }

        public async Task SaveNewTarefa(TarefaDTO tarefaDTO)
        {
            TarefaModel tarefaData = TarefaMapper.ToModel(tarefaDTO);
            await _repository.SaveNewTarefa(tarefaData);
        }
    }
}
