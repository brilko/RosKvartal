using Microsoft.Extensions.Logging;
using ParsingDomGosuslugi.ConfigurationParameters;
using ParsingDomGosuslugi.Requests.Contracts.Interfaces;
using ParsingDomGosuslugi.Requests.Contracts.Models;

namespace ParsingDomGosuslugi.Requests.Implementations
{
    internal class ExaminationsUploader : IExaminationsUploader
    {
        private readonly IExaminationsUri examinationsUri;
        private readonly IExaminationsRequestCreator requestCreator;
        private readonly IExaminationsRequestHandler requestHandler;
        private readonly ILogger<ExaminationsUploader> logger;
        private readonly DateTime startToLoadPeriod;
        private readonly int batchSize;

        public ExaminationsUploader(
            IExaminationsUri examinationsUri,
            IExaminationsRequestCreator requestCreator,
            IExaminationsRequestHandler requestHandler,
            PeriodToLoad periodToLoad,
            BatchSizeParameter batchSizeParameter,
            ILogger<ExaminationsUploader> logger)
        {
            this.examinationsUri = examinationsUri;
            this.requestCreator = requestCreator;
            this.requestHandler = requestHandler;
            startToLoadPeriod = periodToLoad.GetStartDate();
            batchSize = batchSizeParameter.Size;
            this.logger = logger;
        }

        public async Task<string> UploadAsync()
        {
            var batchNumber = 0;
            var response = new ExaminationResponseDto() 
            {
                Total = int.MaxValue
            };
            var examinations = new List<ExaminationDto>();
            while (response.Total > batchNumber * batchSize) 
            {
                batchNumber++;
                response = await UploadBatchAsync(batchNumber);
                examinations = response.Items;
            }
            return "";
        }

        private async Task<ExaminationResponseDto> UploadBatchAsync(int batchNumber) 
        {
            while (true) 
            {
                var request = requestCreator.CreateBaseRequest(startToLoadPeriod);
                request.RequestUri = examinationsUri.BuildUri(batchNumber, batchSize);
                var response = await requestHandler.HandleRequest(request);
                if (response != null)
                    return response;
                Console.WriteLine("Получить данные от сервера не удалось. Ещё одна попытка получить данные. ExaminationsUploader.");
            }
        }
    }
}
