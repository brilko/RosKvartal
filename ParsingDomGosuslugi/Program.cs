using Microsoft.Extensions.DependencyInjection;
using ParsingDomGosuslugi;
using RequestsContracts.Interfaces;

var provider = Registrar.Register();
var uploader = provider.GetService<IExaminationsUploader>() ?? throw new Exception();
var message = await uploader.UploadAsync();
Console.WriteLine(message);

