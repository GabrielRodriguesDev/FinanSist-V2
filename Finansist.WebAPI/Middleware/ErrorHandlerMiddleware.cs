

using Finansist.Domain.Commands;
using Finansist.Domain.Commands.Result;
using Finansist.Domain.Interfaces.Infrastructure;
using Newtonsoft.Json;
using System.Net;

namespace Finansist.WebAPI.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var service = context.RequestServices.GetRequiredService<IErrorManager>();
            var result = new GenericCommandResult(false, $"{service.getCatalogError()} - " + exception.Message);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}