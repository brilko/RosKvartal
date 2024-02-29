using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using ParsingDomGosuslugi;
using ParsingDomGosuslugi.Requests.Contracts.Interfaces;
using ParsingDomGosuslugi.Requests.Implementations;

//HttpClientHandler handler = new HttpClientHandler();
//handler.AutomaticDecompression = DecompressionMethods.All;

//HttpClient client = new HttpClient(handler);

//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dom.gosuslugi.ru/inspection/api/rest/services/examinations/public/search?page=1&itemsPerPage=10");

//request.Headers.Add("Accept", "application/json, text/plain, */*");
//request.Headers.Add("Accept-Language", "ru,en;q=0.9,sr;q=0.8");
//request.Headers.Add("Connection", "keep-alive");
//request.Headers.Add("Origin", "https://dom.gosuslugi.ru");
//request.Headers.Add("Referer", "https://dom.gosuslugi.ru/");
//request.Headers.Add("Request-GUID", "bd82ecfc-0223-458e-8a95-25b48a101421");
//request.Headers.Add("Sec-Fetch-Dest", "empty");
//request.Headers.Add("Sec-Fetch-Mode", "cors");
//request.Headers.Add("Sec-Fetch-Site", "same-origin");
//request.Headers.Add("Session-GUID", "69c3fdf9-6ad7-4bc9-8f11-0a62aabedeab");
//request.Headers.Add("State-GUID", "/rp");
//request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 YaBrowser/24.1.0.0 Safari/537.36");
//request.Headers.Add("X-KL-kfa-Ajax-Request", "Ajax_Request");
//request.Headers.Add("sec-ch-ua", "\"Not_A Brand\";v=\"8\", \"Chromium\";v=\"120\", \"YaBrowser\";v=\"24.1\", \"Yowser\";v=\"2.5\"");
//request.Headers.Add("sec-ch-ua-mobile", "?0");
//request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");

//request.Content = new StringContent("{\"numberOrUriNumber\":null,\"typeList\":[],\"examStartFrom\":\"2024-01-28T21:00:00.000Z\",\"examStartTo\":null,\"orderNumber\":null,\"statusList\":[],\"isAssigned\":null,\"hasOffences\":[],\"preceptsMade\":[],\"formList\":[],\"oversightActivitiesRefList\":[]}");
//request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//HttpResponseMessage response = await client.SendAsync(request);
//response.EnsureSuccessStatusCode();
//string responseBody = await response.Content.ReadAsStringAsync();
//Console.WriteLine(responseBody);


var registrar = new Registrar();
var provider = registrar.Register();
var uploader = provider.GetService<IExaminationsUploader>() ?? throw new Exception();
var startPeriod = DateTime.Today.AddMonths(-1).ToUniversalTime();
var message = await uploader.UploadAsync(startPeriod);
Console.WriteLine(message);