using ConfigurationParameters;
using Microsoft.Extensions.Logging;
using RequestsContracts.Interfaces;
using RequestsContracts.Models;

namespace RequestsImplementations
{
    public class ExaminationsUploader : IExaminationsUploader
    {
        private readonly IExaminationsUri examinationsUri;
        private readonly IExaminationsRequestCreator requestCreator;
        private readonly IExaminationsRequestHandler requestHandler;
        private readonly ILogger<ExaminationsUploader> logger;
        private readonly int batchSize;

        public ExaminationsUploader(
            IExaminationsUri examinationsUri,
            IExaminationsRequestCreator requestCreator,
            IExaminationsRequestHandler requestHandler,
            BatchSizeParameter batchSizeParameter,
            ILogger<ExaminationsUploader> logger)
        {
            this.examinationsUri = examinationsUri;
            this.requestCreator = requestCreator;
            this.requestHandler = requestHandler;
            batchSize = batchSizeParameter.Size;
            this.logger = logger;
        }

        public async Task<ExaminationsResponseModel> UploadBatchAsync(
            int batchNumber, DateTime startToLoadPeriod) 
        {
            while (true) 
            {
                var request = requestCreator.CreateBaseRequest(startToLoadPeriod);
                request.RequestUri = examinationsUri.BuildUri(batchNumber, batchSize);
                var response = await requestHandler.HandleRequest(request);
                if (response != null)
                    return response;
                logger.LogWarning("Получить данные от сервера не удалось. Ещё одна попытка получить данные. ExaminationsUploader.");
            }
        }
    }
}
