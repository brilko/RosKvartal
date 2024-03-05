using Microsoft.Extensions.DependencyInjection;
using ParsingDomGosuslugi;
using ServicesContracts.Interfaces;

var provider = Registrar.Register();
var initializer = provider.GetService<IExaminationsInitializer>() ?? throw new Exception();
await initializer.Initialize();

