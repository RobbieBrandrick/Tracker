using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracker.Core.Data;
using Tracker.Core.Models.Infrastructure.Settings;

namespace Tracker.Core.Services.Infrastructure
{
    public static class ServiceProvider
    {
        private static Microsoft.Extensions.DependencyInjection.ServiceProvider _provider;

        static ServiceProvider()
        {
            
        }

        public static T Get<T>()
        {

            if (_provider == null)
            {
                
                _provider = SetUpServiceProvider();
                
            }
            
            T service = _provider.GetService<T>();

            return service;
            
        }

        public static IConfiguration GetConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            return configuration;

        }

        public static IServiceCollection GetServiceCollection(IConfiguration configuration)
        {

            IServiceCollection collection = new ServiceCollection()
                .Configure<ConnectionStrings>(configuration.GetSection(ConnectionStrings.ConfigSection))
                .AddDbContext<TrackerDbContext>();

            return collection;
            
        }
        

        private static Microsoft.Extensions.DependencyInjection.ServiceProvider SetUpServiceProvider()
        {

            IConfiguration configuration = GetConfiguration();
            IServiceCollection serviceCollection = GetServiceCollection(configuration);
            
            Microsoft.Extensions.DependencyInjection.ServiceProvider serviceProvider =
                serviceCollection.BuildServiceProvider();

            return serviceProvider;
            
        }
    }
}