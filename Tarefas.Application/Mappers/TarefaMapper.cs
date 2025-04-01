using System.Runtime.CompilerServices;
using Tarefas.Application.DTO;
using Tarefas.Domain.Models;

namespace Tarefas.Application.Mappers
{
    internal class TarefaMapper
    {
        internal static TarefaModel ToModel(TarefaDTO dto)
        {
            var model = new TarefaModel
            {
                Id = dto.Id,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                DataCriacao = dto.DataCriacao.HasValue ? dto.DataCriacao.Value : DateTime.Now,
                DataConclusao = dto.DataConclusao,
                StatusTarefa = ConvertStatusDTOStringToEnum(dto.Status)
            };


            model.AplicaValidacoes();

            return model;
        }

        internal static TarefaDTO ToDTO(TarefaModel model)
        {
            var dto = new TarefaDTO
            {
                Id = model.Id,
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                DataCriacao = model.DataCriacao,
                DataConclusao = model.DataConclusao,
                Status = ConvertStatusEnumToDTOString(model.StatusTarefa)
            };

            return dto;
        }

        private static string ConvertStatusEnumToDTOString(StatusTarefa statusTarefa)
        {
            string valor = statusTarefa switch
            {
                StatusTarefa.Pendente => "Pendente",
                StatusTarefa.EmProgresso => "Em Progresso",
                StatusTarefa.Concluida => "Concluída",
                _ => null
            };
            return valor;
        }

        private static StatusTarefa ConvertStatusDTOStringToEnum(string? statusTarefa)
        {
            return statusTarefa switch
            {
                "Pendente" => StatusTarefa.Pendente,
                "Em Progresso" => StatusTarefa.EmProgresso,
                "Concluída" => StatusTarefa.Concluida,
                _ => StatusTarefa.Pendente
            };
        }


    }
}
