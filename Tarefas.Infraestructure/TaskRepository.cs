using Dapper;
using System.Data.Common;
using System.Data.SqlClient;
using Tarefas.Domain.Models;

namespace Tarefas.Infraestructure
{
    public class TaskRepository
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //Por ser um programa simples, optei por implementar o Singleton aqui dentro do próprio repositório.
        //Para um programa onde mais tabelas seriam acessadas, eu criaria uma classe e a instanciaria em meu program.cs dentro de
        //Tarefas.Presentation, e passaria essa instancia de conexão para os services (que repassariam aos repositories)
        //na injeção de dependências.
        private SqlConnection GetOpenConnection()
        {
            if (_connection == null || string.IsNullOrEmpty(_connection.ConnectionString))
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
                return _connection;
            }
            return _connection;
        }

        public async Task SaveNewTask(TaskModel tarefaData)
        {
            const string query = @"
                INSERT INTO TAREFAS(TITULO, DESCRICAO, DATACRIACAO, DATACONCLUSAO, STATUSID)
                VALUES(@Titulo, @Descricao, @DataCriacao, @DataConclusao, 0)
            ";

            await using var conn = GetOpenConnection();
            await conn.ExecuteAsync(query, tarefaData);
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasks()
        {
            const string query = @"
                SELECT * FROM TAREFAS     
            ";

            await using var conn = GetOpenConnection();
            return await conn.QueryAsync<TaskModel>(query);
        }

        public async Task<TaskModel?> GetTaskById(int tarefaId)
        {
            const string query = @"
                SELECT * FROM TAREFAS WHERE ID = @Id
            ";

            await using var conn = GetOpenConnection();
            return await conn.QuerySingleOrDefaultAsync<TaskModel>(query, new { Id = tarefaId });
        }

        public async Task<int> DeleteTask(int tarefaId)
        {
            const string query = @"
                DELETE FROM TAREFAS WHERE ID = @Id
            ";

            await using var conn = GetOpenConnection();
            return await conn.ExecuteAsync(query, new { Id = tarefaId }); ;
        }

        public async Task<int> UpdateTask(TaskModel tarefaModel)
        {
            const string query = @"
                UPDATE TAREFAS 
                SET 
                TITULO = @Titulo,
                DESCRICAO = @Descricao, 
                DATACONCLUSAO = @DataConclusao,
                STATUSID = @StatusTarefa
                WHERE ID = @Id 
            ";

            await using var conn = GetOpenConnection();
            return await conn.ExecuteAsync(query, new
            {
                Id = tarefaModel.Id,
                StatusTarefa = tarefaModel.StatusId,
                Titulo = tarefaModel.Titulo,
                Descricao = tarefaModel.Descricao,
                DataConclusao = tarefaModel.DataConclusao
            }); ;

        }

    }
}
