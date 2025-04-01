using System.ComponentModel.DataAnnotations;

namespace Tarefas.Domain.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public StatusTarefa StatusTarefa { get; set; }
        
        public void AplicaValidacoes()
        {
            ValidaDataConclusao();
            ValidaTitulo();
            ValidaDescricao();
        }

        private void ValidaDataConclusao()
        {
            if(DataConclusao.HasValue && DataConclusao < DataCriacao)
            {
                throw new ValidationException("A Data de Conclusão não pode ser menor que a Data de Criação!");
            }
        }

        private void ValidaTitulo()
        {
            if(Titulo.Length > 100)
            {
                throw new ValidationException("O Título deve conter no máximo 100 caracteres!");
            }

            if (string.IsNullOrEmpty(Titulo))
            {
                throw new ValidationException("O Título não pode ser vazio!");
            }
        }

        private void ValidaDescricao()
        {
            if (Descricao.Length > 255)
            {
                throw new ValidationException("A Descrição deve conter no máximo 255 caracteres!");
            }
        }


    }
}
