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

        public async Task<List<TarefaDTO>> GetAllTarefas()
        {
            var data = await _repository.GetAllTarefas();

            List<TarefaDTO> tarefasDTO = new List<TarefaDTO>();

            foreach(TarefaModel tarefa in data)
            {
                tarefasDTO.Add(TarefaMapper.ToDTO(tarefa));
            }

            return tarefasDTO;
        }

        public async Task SaveNewTarefa(TarefaDTO tarefaDTO)
        {
            TarefaModel tarefaData = TarefaMapper.ToModel(tarefaDTO);
            await _repository.SaveNewTarefa(tarefaData);
        }
    }
}
