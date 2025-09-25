using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Application.Exceptions;

namespace Infrastructure.Middlewore
{
    public class Middlewore
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Middlewore> _logger;

        public Middlewore(RequestDelegate next, ILogger<Middlewore> logger)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error capturado por middleware.");
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            string message = ex.Message;

            switch (ex)
            {
                case BadRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case ConflictException:
                    statusCode = HttpStatusCode.Conflict;
                    break;
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "Ocurrió un error inesperado.";
                    break;
            }

            var result = JsonSerializer.Serialize(new { error = message , statusCode = (int)statusCode});

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(result);
        }


    }
}
