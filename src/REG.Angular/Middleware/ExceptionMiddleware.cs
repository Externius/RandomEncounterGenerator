using Microsoft.AspNetCore.Localization;
using REG.Core.Abstractions.Services.Exceptions;
using System.Globalization;
using System.Net;
using System.Text.Json;

namespace REG.Angular.Middleware;

public class ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment webHostEnvironment)
{
    private readonly RequestDelegate _next = next;
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

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
        SetCurrentCulture(context);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var message = "Internal Generic Error";
        var stackTrace = "";

        if (_webHostEnvironment.EnvironmentName.StartsWith("Development"))
            stackTrace = exception.StackTrace;

        switch (exception)
        {
            case ServiceAggregateException aex:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                message = string.Join(" ",
                    aex.GetInnerExceptions().Select(serviceException =>
                        serviceException.LocalizedMessage(Resources.Error.ResourceManager)));
                break;
            case ServiceException ex:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                message = ex.LocalizedMessage(Resources.Error.ResourceManager);
                break;
        }

        return context.Response.WriteAsync(JsonSerializer.Serialize(new
            { context.Response.StatusCode, Message = message, StackTrace = stackTrace }));
    }

    private static void SetCurrentCulture(HttpContext context)
    {
        var culture = context.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture;
        if (culture is null)
            return;
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
    }
}