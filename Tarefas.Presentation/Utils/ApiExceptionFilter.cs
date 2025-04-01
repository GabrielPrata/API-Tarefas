using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;

public class ApiExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        int statusCode = 500;
        object response;

        if (context.Exception is JsonReaderException jsonEx)
        {
            statusCode = 400;
            response = new
            {
                message = "Erro na leitura do JSON. Verifique o formato do arquivo.",
                detalhes = jsonEx.Message
            };
        }
        else if (context.Exception is ValidationException validEx)
        {
            statusCode = 400;
            response = new
            {
                message = "Erro de validação.",
                detalhes = validEx.Message
            };
        }
        else if (context.Exception is SqlException sqlEx)
        {
            statusCode = 500;
            response = new
            {
                message = "Ocorreu um erro com o banco de dados.",
                detalhes = sqlEx.Message
            };
        }
        else
        {
            response = new
            {
                message = "Ocorreu um erro inesperado.",
                detalhes = context.Exception.Message
            };
        }

        context.Result = new ObjectResult(response)
        {
            StatusCode = statusCode
        };

        context.ExceptionHandled = true;
    }
}
