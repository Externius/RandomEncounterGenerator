using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using REG.Core.Abstractions.Services.Exeptions;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace REG.Angular.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment webHostEnvironment)
        {
            _next = next;
            _webHostEnvironment = webHostEnvironment;
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

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var message = "Internal Generic Error";
            var stackTrace = "";

            if (_webHostEnvironment.EnvironmentName.StartsWith("Development"))
                stackTrace = exception.StackTrace;

            if (exception is ServiceAggregateException aex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                message = string.Join(" ", aex.InnerExceptions.Select(serviceException => serviceException.LocalizedMessage(Resources.Error.ResourceManager)));
            }
            else if (exception is ServiceException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                message = ex.LocalizedMessage(Resources.Error.ResourceManager);
            }

            return context.Response.WriteAsync(JsonSerializer.Serialize(new { context.Response.StatusCode, Message = message, StackTrace = stackTrace }));
        }
    }
}
