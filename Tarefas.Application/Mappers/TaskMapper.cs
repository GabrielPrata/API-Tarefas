using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Tarefas.Application.DTO;
using Tarefas.Domain.Models;

namespace Tarefas.Application.Mappers
{
    internal class TaskMapper
    {
        internal static TaskModel ToModel(TaskDTO dto)
        {
            var model = new TaskModel
            {
                Id = dto.Id,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                DataCriacao = DateTime.Now,
                DataConclusao = dto.DataConclusao,
                StatusId = ConvertStatusDTOStringToEnum(dto.Status)
            };


            model.ApplyValidations();

            return model;
        }

        internal static TaskDTO ToDTO(TaskModel model)
        {

            return new TaskDTO
            {
                Id = model.Id,
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                DataCriacao = model.DataCriacao,
                DataConclusao = model.DataConclusao,
                Status = ConvertStatusEnumToDTOString(model.StatusId)
            }; ;
        }

        private static string ConvertStatusEnumToDTOString(TaskStatus statusTarefa)
        {
            string valor = statusTarefa switch
            {
                TaskStatus.Pendente => "Pendente",
                TaskStatus.EmProgresso => "Em Progresso",
                TaskStatus.Concluida => "Concluída",
                _ => throw new ValidationException("Status para a tarefa incorreto!")
            };
            return valor;
        }

        private static TaskStatus ConvertStatusDTOStringToEnum(string? statusTarefa)
        {
            return statusTarefa switch
            {
                "Pendente" => TaskStatus.Pendente,
                "Em Progresso" => TaskStatus.EmProgresso,
                "Concluída" => TaskStatus.Concluida,
                _ => throw new ValidationException("Status para a tarefa incorreto!")
            };
        }


    }
}
