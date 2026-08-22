using REG.Core;
using REG.Core.Abstractions.Settings;
using REG.WebApi;
using REG.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection()
    .UseCors(CorsSettings.Policy)
    .UseRequestLocalization();

app.MapControllers();
app.Run();