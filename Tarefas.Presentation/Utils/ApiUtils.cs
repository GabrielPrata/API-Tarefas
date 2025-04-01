using Tarefas.Application;

namespace API_Tarefas.Utils
{
    public class ApiUtils
    {
        internal static string GetConnectionString(IConfiguration config) {
            var configurations = config.GetSection("AppConfiguration").Get<AppConfiguration>();

            return configurations.ConnectionString;
        }
    }
}
