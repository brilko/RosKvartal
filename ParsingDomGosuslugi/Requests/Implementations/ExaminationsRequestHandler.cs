using AutoMapper;
using Microsoft.Extensions.Logging;
using ParsingDomGosuslugi.Requests.Contracts.Interfaces;
using ParsingDomGosuslugi.Requests.Contracts.Models;
using System.Net.Http.Json;

namespace ParsingDomGosuslugi.Requests.Implementations
{
    internal class ExaminationsRequestHandler : IExaminationsRequestHandler
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly ILogger<ExaminationsRequestHandler> logger;
        private readonly IMapper mapper;
        public ExaminationsRequestHandler(
            IHttpClientFactory clientFactory,
            ILogger<ExaminationsRequestHandler> logger,
            IMapper mapper)
        {
            this.clientFactory = clientFactory;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<ExaminationsResponseModel?> HandleRequest(HttpRequestMessage request)
        {
            HttpClient client = clientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.SendAsync(request);
            logger.LogInformation($"{(int)responseMessage.StatusCode} {responseMessage.ReasonPhrase}");
            if (!responseMessage.IsSuccessStatusCode)
                return null;
            var responseModel = await responseMessage
                .Content
                .ReadFromJsonAsync<ExaminationsResponseModel>()
                ?? throw new Exception();
            var responseDto = mapper.Map
            return response;
        }
    }
}
