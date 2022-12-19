﻿using Microsoft.AspNetCore.Localization;
using REG.Core.Abstractions.Services;
using REG.Core.Abstractions.Settings;
using REG.Core.Services;
using System.Globalization;

namespace REG.Angular;

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

            builder.WithOrigins(corsSettings?.Urls ?? new[] { "https://localhost:4200" })
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));

        services.Configure<RequestLocalizationOptions>(
            opts =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new("hu"),
                    new("en"),
                };
                opts.DefaultRequestCulture = new RequestCulture("en");
                opts.SupportedCultures = supportedCultures;
                opts.SupportedUICultures = supportedCultures;
                opts.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });

        services.AddControllers();
        // In production, the Angular files will be served from this directory
        services.AddSpaStaticFiles(staticFilesOptions =>
        {
            staticFilesOptions.RootPath = "ClientApp/dist";
        });

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEncounterService, EncounterService>()
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
