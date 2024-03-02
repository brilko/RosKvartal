using ParsingDomGosuslugi.Requests.Contracts.Interfaces;
using ParsingDomGosuslugi.Requests.Contracts.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace ParsingDomGosuslugi.Requests.Implementations
{
    internal class ExaminationsRequestHandler: IExaminationsRequestHandler
    {
        private readonly IHttpClientFactory clientFactory;
        public ExaminationsRequestHandler(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<ExaminationsResponseModel> HandleRequest(HttpRequestMessage request)
        {
            HttpClient client = clientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.SendAsync(request);
            responseMessage.EnsureSuccessStatusCode();
            var response = await responseMessage
                .Content
                .ReadFromJsonAsync<ExaminationsResponseModel>()
                ?? throw new Exception();
            return response;
        }
    }
}
