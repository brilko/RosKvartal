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
            var response = new ExaminationsResponseModel() 
            {
                Total = int.MaxValue
            };
            var examinations = new List<ExaminationDto>();
            while (response.Total > batchNumber * batchSize) 
            {
                batchNumber++;
                response = await UploadBatchAsync(batchNumber);
                var items = response.Items;
            }


            return "";
        }

        private async Task<ExaminationsResponseModel> UploadBatchAsync(int batchNumber) 
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

        private ExaminationsResponseModel CreateTestModels()
        {
            var responseTest = new ExaminationsResponseModel();
            var testString = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq";
            for (var indexer = 0; indexer < 1000; indexer++)
            {
                responseTest.Items.Add(new ExaminationModel()
                {
                    ExaminationCompletionStatus = testString,
                    ExamObjective = testString,
                    HasOffence = false,
                    Subject = new ExaminationSubjectModel()
                    {
                        OrganizationInfoEnriched = new OrganizationInfoEnriched()
                        {
                            RegistryOrganizationCommonDetailWithNsi = new RegistryOrganizationCommonDetailWithNsi()
                            {
                                FullName = testString,
                                Ogrn = testString,
                            }
                        }
                    }
                });
            }
            return responseTest;
        }
    }
}
