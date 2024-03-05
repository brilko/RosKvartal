using AutoMapper;
using ConfigurationParameters;
using Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RepositoryContracts.Intefaces;
using RepositoryImplementations;
using RequestsContracts.Interfaces;
using RequestsImplementations;
using ServicesContracts.Interfaces;
using ServicesImplementation;

namespace ParsingDomGosuslugi
{
    internal static class Registrar
    {
        public static ServiceProvider Register()
        {
            var configuration = ConfigurationExtension.BuildConfiguration();
            var services = CreateServices(configuration);
            var provider = services.BuildServiceProvider();
            return provider;
        }

        private static IServiceCollection CreateServices(IConfigurationRoot configuration)
        {
            return new ServiceCollection()
                .AddBuildInServices()
                .AddMappers()
                .AddDataBase(configuration)
                .AddParametersFromConfiguration(configuration)
                .AddCustomServices();
        }

        private static IServiceCollection AddBuildInServices(this IServiceCollection services)
        {
            return services
                .AddHttpClient();
        }

        private static IServiceCollection AddMappers(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ExaminationProfile>();
                cfg.AddProfile<ExaminationResponseProfile>();
            });
            configuration.AssertConfigurationIsValid();

            return services
                .AddSingleton<IMapper>(new Mapper(configuration));
        }

        private static IServiceCollection AddDataBase(this IServiceCollection services,
            IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetConnectionString("examinationsDatabaseConnectionString");
            services
                .AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString))
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IExaminationRepository, ExaminationRepository>()
                .AddScoped<IUpdateDateRepository, UpdateDateRepository>();
            return services;
        }

        private static IServiceCollection AddParametersFromConfiguration(
            this IServiceCollection services, IConfigurationRoot configuration)
        {
            return services
                .AddParameter<ExaminationsUriConfigParams>("ExaminationsUriConfigParams", configuration)
                .AddParameter<LoadPeriodForInitial>("PeriodToInitialLoad", configuration)
                .AddParameter<BatchSizeParameter>("BatchSize", configuration);
        }

        private static IServiceCollection AddParameter<T>(this IServiceCollection services,
            string sectionKey, IConfigurationRoot configuration) where T : class
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
                .AddScoped<IExaminationsUri, ExaminationsUri>()
                .AddScoped<IExaminationsBatchLoader, ExaminationsBatchLoader>()
                
                .AddScoped<IExaminationsInitializer, ExaminationsInitializer>()
                .AddScoped<ILoadBatchesAndActAdapter, LoadBatchesAndActAdapter>();
        }
    }
}
