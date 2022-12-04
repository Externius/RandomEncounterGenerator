using REG.Angular.Middleware;

namespace REG.Angular;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddWebServices()
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

        app.UseCors("default");

        app.MapControllers();
        app.MapFallbackToFile("index.html");

        app.Run();
    }
}