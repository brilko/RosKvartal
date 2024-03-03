using AutoMapper;
using Microsoft.Extensions.Logging;
using RequestsContracts.Interfaces;
using RequestsContracts.Models;
using System.Net.Http.Json;

namespace RequestsImplementations
{
    public class ExaminationsRequestHandler : IExaminationsRequestHandler
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly ILogger<ExaminationsRequestHandler> logger;
        public ExaminationsRequestHandler(
            IHttpClientFactory clientFactory,
            ILogger<ExaminationsRequestHandler> logger)
        {
            this.clientFactory = clientFactory;
            this.logger = logger;
        }

        public async Task<ExaminationsResponseModel?> HandleRequest(HttpRequestMessage request)
        {
            HttpClient client = clientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.SendAsync(request);
            logger.LogInformation($"{(int)responseMessage.StatusCode} {responseMessage.ReasonPhrase}");
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
