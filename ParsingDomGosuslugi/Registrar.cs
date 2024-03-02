using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParsingDomGosuslugi.Requests.ConfigurationParameters;
using ParsingDomGosuslugi.Requests.Contracts.Interfaces;
using ParsingDomGosuslugi.Requests.Implementations;
using System.Runtime.CompilerServices;

namespace ParsingDomGosuslugi
{
    internal static class Registrar
    {
        private static readonly IConfigurationRoot configuration = ConfigurationExtension.BuildConfiguration();
        public static ServiceProvider Register() 
        {
            var services = CreateServices();
            var provider = services.BuildServiceProvider();
            return provider;
        }

        private static IServiceCollection CreateServices() 
        {
            return new ServiceCollection()
                .AddBuildInServices()
                .AddParametersFromConfiguration()
                .AddCustomServices();
        }

        private static IServiceCollection AddBuildInServices(this IServiceCollection services) 
        {
            return services
                .AddHttpClient();
        }

        private static IServiceCollection AddParametersFromConfiguration(
            this IServiceCollection services) 
        {
            return services
                .AddParameter<ExaminationsUriConfigParams>("ExaminationsUriConfigParams")
                .AddParameter<PeriodToLoad>("PeriodToLoad")
                .AddParameter<BatchSizeParameter>("BatchSize");
        }

        private static IServiceCollection AddParameter<T>(this IServiceCollection services, 
            string sectionKey) where T : class
        {
            var parsedObject = configuration.GetFromSection<T>(sectionKey);
            return services.AddScoped(_ => parsedObject);
        }

        private static IServiceCollection AddCustomServices(this IServiceCollection services) 
        {
            return services
                .AddScoped<IExaminationsRequestCreator, ExaminationsRequestCreator>()
                .AddScoped<IExaminationsRequestHandler, ExaminationsRequestHandler>()
                .AddScoped<IExaminationsUploader, ExaminationsUploader>()
                .AddScoped<IExaminationsUri, ExaminationsUri>();
        }
    }
}
