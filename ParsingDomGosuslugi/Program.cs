using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using ParsingDomGosuslugi;
using ParsingDomGosuslugi.Requests.Contracts.Interfaces;
using ParsingDomGosuslugi.Requests.Implementations;

var provider = Registrar.Register();
var uploader = provider.GetService<IExaminationsUploader>() ?? throw new Exception();
var message = await uploader.UploadAsync();
Console.WriteLine(message);

