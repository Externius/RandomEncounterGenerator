using System.Globalization;
using Microsoft.AspNetCore.Localization;
using REG.Core.Abstractions.Settings;

namespace REG.WebApi;

public static class ConfigureServices
{
    public static IServiceCollection AddWebServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddCors(o => o.AddPolicy(CorsSettings.Policy, builder =>
        {
            var corsSettings = configuration.GetSection(nameof(CorsSettings)).Get<CorsSettings>();

            builder.WithOrigins(corsSettings?.Urls ?? ["https://localhost:4200"])
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));

        services.Configure<RequestLocalizationOptions>(opts =>
        {
            var supportedCultures = (List<CultureInfo>)
            [
                new CultureInfo("hu"),
                new CultureInfo("en")
            ];
            opts.DefaultRequestCulture = new RequestCulture("en");
            opts.SupportedCultures = supportedCultures;
            opts.SupportedUICultures = supportedCultures;
            opts.RequestCultureProviders =
            [
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
            ];
        });
        
        services.AddControllers();
        
        return services;
    }
}