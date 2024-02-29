using ParsingDomGosuslugi.Requests.Contracts.Interfaces;
using System.Net;
using System.Net.Http;

namespace ParsingDomGosuslugi.Requests.Implementations
{
    internal class ExaminationsRequestHandler: IExaminationsRequestHandler
    {
        private readonly IHttpClientFactory clientFactory;
        public ExaminationsRequestHandler(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<string> HandleRequest(HttpRequestMessage request)
        {
            HttpClient client = clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
