using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using REG.Core.Abstractions.Services;
using REG.Core.Services;
using System;
using System.IO;

namespace REG.Core.Test
{
    public class TestEnvironment : IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScope _scope;

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

            _serviceProvider = services.BuildServiceProvider();
            _scope = _serviceProvider.CreateScope();
        }

        public T GetService<T>()
        {
            return _scope.ServiceProvider.GetService<T>();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder => {
                builder.AddDebug();
            });
            services.AddApplicationServices()
                .AddAutoMapper(typeof(Services.Automapper.EncounterProfile));
        }

        public void Dispose()
        {
            _scope?.Dispose();
            Connection?.Dispose();
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
}
