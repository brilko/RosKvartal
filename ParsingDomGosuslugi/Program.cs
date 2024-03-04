using Microsoft.Extensions.DependencyInjection;
using ParsingDomGosuslugi;
using ServicesContracts.Interfaces;

var provider = Registrar.Register();
var updater = provider.GetService<IExaminationsUpdater>() ?? throw new Exception();
await updater.Initialize();

