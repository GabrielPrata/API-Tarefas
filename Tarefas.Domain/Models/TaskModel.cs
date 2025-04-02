using System.ComponentModel.DataAnnotations;

namespace Tarefas.Domain.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public TaskStatus StatusId { get; set; }
        
        public void ApplyValidations()
        {
            ValidateDataConclusao();
            ValidateTitulo();
            ValidateDescricao();
        }

        private void ValidateDataConclusao()
        {
            if(DataConclusao.HasValue && DataConclusao < DataCriacao)
            {
                throw new ValidationException("A Data de Conclusão não pode ser menor que a Data de Criação!");
            }
        }

        private void ValidateTitulo()
        {
            if(Titulo.Length > 100)
            {
                throw new ValidationException("O Título deve conter no máximo 100 caracteres!");
            }

            if (string.IsNullOrEmpty(Titulo.Trim()))
            {
                throw new ValidationException("O Título não pode ser vazio!");
            }
        }

        private void ValidateDescricao()
        {
            if (Descricao.Length > 255)
            {
                throw new ValidationException("A Descrição deve conter no máximo 255 caracteres!");
            }
        }


    }
}
