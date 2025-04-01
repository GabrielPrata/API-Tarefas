using Dapper;
using System.Data.Common;
using System.Data.SqlClient;
using Tarefas.Domain.Models;

namespace Tarefas.Infraestructure
{
    public class TarefaRepository
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public TarefaRepository(string connectionString)
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

        public async Task SaveNewTarefa(TarefaModel tarefaData)
        {
            const string query = @"
                INSERT INTO TAREFAS(TITULO, DESCRICAO, DATACRIACAO, DATACONCLUSAO, STATUSID)
                VALUES(@Titulo, @Descricao, @DataCriacao, @DataConclusao, @StatusTarefa)
            ";

            await using var conn = GetOpenConnection();
            await conn.ExecuteAsync(query, tarefaData);
        }

        public async Task<IEnumerable<TarefaModel>> GetAllTarefas()
        {
            const string query = @"
                SELECT * FROM TAREFAS     
            ";

            await using var conn = GetOpenConnection();
            var tarefasData = await conn.QueryAsync<TarefaModel>(query);

            return tarefasData;
        }

        public async Task<TarefaModel?> GetTarefaById(int tarefaId)
        {
            const string query = @"
                SELECT * FROM TAREFAS WHERE ID = @Id
            ";

            await using var conn = GetOpenConnection();
            var tarefa = await conn.QuerySingleOrDefaultAsync<TarefaModel>(query, new { Id = tarefaId });

            return tarefa;
        }

        public async Task<int> DeleteTarefa(int tarefaId)
        {
            const string query = @"
                DELETE FROM TAREFAS WHERE ID = @Id
            ";

            await using var conn = GetOpenConnection();
            int deleteRealizado = await conn.ExecuteAsync(query, new { Id = tarefaId });

            return deleteRealizado;
        }

       

    }
}
