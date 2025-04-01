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

        public async Task<TarefaDTO> GetTarefaById(int tarefaId)
        {
            TarefaModel data = await _repository.GetTarefaById(tarefaId);

            if (data == null)
            {
                return null;
            }

            TarefaDTO tarefasDTO = TarefaMapper.ToDTO(data);    

            return tarefasDTO;
        }

        public async Task<int> DeleteTarefa(int tarefaId)
        {
           int deleteRealizado = await _repository.DeleteTarefa(tarefaId);
            return deleteRealizado;
        }
    }
}
