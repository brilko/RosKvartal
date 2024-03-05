using AutoMapper;
using ConfigurationParameters;
using Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryContracts.Intefaces;
using RepositoryImplementations;
using RequestsContracts.Interfaces;
using RequestsImplementations;
using ServicesContracts.Interfaces;
using ServicesImplementation;

namespace RosKvartal
{
    internal static class Registrar
    {
        public static WebApplicationBuilder ResgisterServicesExtension(this WebApplicationBuilder builder)
        {
            builder
                .AddParametersFromConfiguration()
                .AddDataBase()
                .Services
                .AddBuildInServices()
                .AddMappers()
                .AddCustomServices();
            return builder;
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
                cfg.AddProfile<SearchPageProfile>();
            });
            configuration.AssertConfigurationIsValid();

            return services
                .AddSingleton<IMapper>(new Mapper(configuration));
        }

        private static WebApplicationBuilder AddDataBase(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration
                .GetConnectionString("examinationsDatabaseConnectionString");
            builder.Services
                .AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString))
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IExaminationRepository, ExaminationRepository>()
                .AddScoped<IUpdateDateRepository, UpdateDateRepository>();
                return builder;
        }

        private static WebApplicationBuilder AddParametersFromConfiguration(
            this WebApplicationBuilder builder)
        {
            return builder
                .ConfigureParameter<ExaminationsUriConfigParams>("ExaminationsUriConfigParams")
                .ConfigureParameter<LoadPeriodForInitial>("LoadPeriodForInitial")
                .ConfigureParameter<LoadPeriodForUpdate>("LoadPeriodForUpdate")
                .ConfigureParameter<PeriodBetweenLoads>("PeriodBetweenUpdates")
                .ConfigureParameter<BatchSizeParameter>("BatchSize");
        }

        private static WebApplicationBuilder ConfigureParameter<T>(this WebApplicationBuilder builder,
            string keySection) where T : class
        {
            var parsedObject = builder
                .Configuration
                .GetSection(keySection)
                .Get<T>()
                ?? throw new Exception();
            builder
                .Services
                .AddScoped(_ => parsedObject);
            return builder;
        }

        private static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IExaminationsRequestCreator, ExaminationsRequestCreator>()
                .AddScoped<IExaminationsRequestHandler, ExaminationsRequestHandler>()
                .AddScoped<IExaminationsUploader, ExaminationsUploader>()
                .AddScoped<IExaminationsUri, ExaminationsUri>()
                .AddScoped<IExaminationsBatchLoader, ExaminationsBatchLoader>()

                .AddScoped<IExaminationsUpdater, ExaminationsUpdater>()
                .AddScoped<IExaminationPageReader, ExaminationPageReader>()
                .AddScoped<ILoadBatchesAndActAdapter, LoadBatchesAndActAdapter>();
        }

        public static void StartPeriodicExaminationsUpdateLoopExtension(
            this WebApplication app)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await app.StartPeriodicExaminationsUpdate();
                }
            });
        }

        private static async Task StartPeriodicExaminationsUpdate(
            this WebApplication app) 
        {
            var scope = app.Services.CreateScope();
            var updater = scope
                .ServiceProvider
                .GetService<IExaminationsUpdater>()
                ?? throw new Exception();

            await updater.Update();

            var periodBetweenUpdates = scope
                .ServiceProvider
                .GetService<PeriodBetweenLoads>()
                ?? throw new Exception();
            scope.Dispose();
            Thread.Sleep(periodBetweenUpdates.ToTimeSpan());
        }
    }
}
