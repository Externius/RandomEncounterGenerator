using REG.Angular.Middleware;
using REG.Core.Abstractions.Settings;

namespace REG.Angular;

public class Program
{
    public static void Main(string[] args)
    {
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

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseCors(CorsSettings.Policy);

        app.UseRequestLocalization();

        app.MapControllers();
        app.MapFallbackToFile("index.html");

        app.Run();
    }
}