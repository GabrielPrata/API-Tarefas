namespace Tarefas.Application.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string? Status { get; set; }
    }
}
