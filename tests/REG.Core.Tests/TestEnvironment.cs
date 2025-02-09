using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using REG.Core.Abstractions.Services;
using REG.Core.Services;
using System;
using System.IO;

namespace REG.Core.Tests;

public sealed class TestEnvironment : IDisposable
{
    private readonly IServiceScope _scope;
    private bool _disposedValue;
    private SqliteConnection Connection { get; }

    public TestEnvironment()
    {
        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
        configurationBuilder.AddJsonFile(configFile);

        Connection = new SqliteConnection("DataSource=:memory:");
        Connection.Open();

        var services = new ServiceCollection();

        ConfigureServices(services);

        _scope = services.BuildServiceProvider().CreateScope();
    }

    public T GetService<T>()
    {
        return _scope.ServiceProvider.GetService<T>();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(builder => { builder.AddDebug(); });
        services.AddApplicationServices()
            .AddAutoMapper(typeof(Services.AutoMapper.EncounterProfile));
    }

    ~TestEnvironment() => Dispose(false);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposedValue)
            return;

        if (disposing)
        {
            Connection?.Dispose();
            _scope?.Dispose();
        }

        _disposedValue = true;
    }
}

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEncounterService, EncounterService>();

        return services;
    }
}