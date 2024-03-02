using ParsingDomGosuslugi.Requests.ConfigurationParameters;
using ParsingDomGosuslugi.Requests.Contracts.Interfaces;
using ParsingDomGosuslugi.Requests.Contracts.Models;

namespace ParsingDomGosuslugi.Requests.Implementations
{
    internal class ExaminationsUploader : IExaminationsUploader
    {
        private readonly IExaminationsUri examinationsUri;
        private readonly IExaminationsRequestCreator requestCreator;
        private readonly IExaminationsRequestHandler requestHandler;
        private readonly DateTime startToLoadPeriod;
        private readonly int batchSize;

        public ExaminationsUploader(
            IExaminationsUri examinationsUri,
            IExaminationsRequestCreator requestCreator,
            IExaminationsRequestHandler requestHandler,
            PeriodToLoad periodToLoad,
            BatchSizeParameter batchSizeParameter)
        {
            this.examinationsUri = examinationsUri;
            this.requestCreator = requestCreator;
            this.requestHandler = requestHandler;
            startToLoadPeriod = periodToLoad.GetStartDate();
            batchSize = batchSizeParameter.Size;
        }

        public async Task<string> UploadAsync()
        {
            var request = requestCreator.CreateBaseRequest(startToLoadPeriod);
            request.RequestUri = examinationsUri.BuildUri(1, batchSize);
            var response = await requestHandler.HandleRequest(request);
            return "";
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
