using Microsoft.Extensions.DependencyInjection;
using REG.Core.Abstractions.Services;
using REG.Core.Services;

namespace REG.Core;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEncounterService, EncounterService>();

        return services;
    }
}