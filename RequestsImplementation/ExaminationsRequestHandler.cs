using RequestsContracts.Interfaces;
using RequestsContracts.Models;
using System.Net.Http.Json;

namespace RequestsImplementations
{
    public class ExaminationsRequestHandler : IExaminationsRequestHandler
    {
        private readonly IHttpClientFactory clientFactory;
        public ExaminationsRequestHandler(
            IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<ExaminationsResponseModel?> HandleRequest(HttpRequestMessage request)
        {
            HttpClient client = clientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.SendAsync(request);
            Console.WriteLine($"{(int)responseMessage.StatusCode} {responseMessage.ReasonPhrase}. ExaminationsRequestHandler");
            if (!responseMessage.IsSuccessStatusCode)
                return null;
            var response = await responseMessage
                .Content
                .ReadFromJsonAsync<ExaminationsResponseModel>()
                ?? throw new Exception();
            return response;
        }
    }
}
