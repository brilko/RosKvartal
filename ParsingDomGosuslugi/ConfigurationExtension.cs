using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace ParsingDomGosuslugi
{
    internal static class ConfigurationExtension
    {
        public static IConfigurationRoot BuildConfiguration()
        {
            var configFilePath = Environment.CurrentDirectory;
            var lastIndex = configFilePath.LastIndexOf("\\bin\\");
            configFilePath = configFilePath.Remove(lastIndex);
            configFilePath += "\\configuration.json";
            var config = new ConfigurationBuilder()
                    .AddJsonFile(configFilePath)
                    .Build();
            return config;
        }

        public static T GetFromSection<T>(this IConfigurationRoot configuration, string sectionKey)
        {
            var section = configuration.GetSection(sectionKey);
            var parsedObject = section.Get<T>() ??
                throw new Exception();
            return parsedObject;
        }
    }
}
