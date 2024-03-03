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

        //public async Task<List<ExaminationDto>> UploadAsync()
        //{
        //    var batchNumber = 0;
        //    var response = new ExaminationResponseDto() 
        //    {
        //        Total = int.MaxValue
        //    };
        //    var examinations = new List<ExaminationDto>();
        //    while (response.Total > batchNumber * batchSize) 
        //    {
        //        batchNumber++;
        //        response = await UploadBatchAsync(batchNumber);
        //        examinations.AddRange(response.Items);
        //    }
        //    return examinations;
        //}

        public async Task<ExaminationsResponseModel> UploadBatchAsync(int batchNumber) 
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
