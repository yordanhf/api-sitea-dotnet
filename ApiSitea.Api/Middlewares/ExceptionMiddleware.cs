using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using FluentValidation;

namespace ApiSitea.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (KeyNotFoundException knf)
            {
                _logger.LogWarning(knf, "Recurso no encontrado");
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new { Message = "Recurso no encontrado" });
                await context.Response.WriteAsync(result);
            }
            catch (ValidationException vEx)
            {
                _logger.LogWarning(vEx, "Error de validación");
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new { Message = "Error de validación", Details = vEx.Errors.Select(e => e.ErrorMessage) });
                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new { Message = "Ocurrió un error interno." });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
