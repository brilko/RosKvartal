using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParsingDomGosuslugi.Requests.Contracts.Interfaces;
using ParsingDomGosuslugi.Requests.Implementations;

namespace ParsingDomGosuslugi
{
    internal class Registrar
    {
        public ServiceProvider Register() 
        {
            //var config = new ConfigurationBuilder()
            //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //        .AddJsonFile(@"./appsettings.json")
            //        .Build();

            //var section = config.GetSection("ExaminationsUriConfigParams");
            //var examinationsUriParams = section.Get<ExaminationsUriConfigParams>() ??
            //    throw new Exception();

            var services = new ServiceCollection()
                .AddHttpClient()
                .AddScoped(_ => new ExaminationsUriConfigParams())
                .AddScoped<IExaminationsRequestCreator, ExaminationsRequestCreator>()
                .AddScoped<IExaminationsRequestHandler, ExaminationsRequestHandler>()
                .AddScoped<IExaminationsUploader, ExaminationsUploader>()
                .AddScoped<IExaminationsUri, ExaminationsUri>();

            var provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
