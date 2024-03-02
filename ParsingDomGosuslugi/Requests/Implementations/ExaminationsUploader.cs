using ParsingDomGosuslugi.Requests.Contracts.Interfaces;

namespace ParsingDomGosuslugi.Requests.Implementations
{
    internal class ExaminationsUploader: IExaminationsUploader
    {
        private readonly IExaminationsUri examinationsUri;
        private readonly IExaminationsRequestCreator requestCreator;
        private readonly IExaminationsRequestHandler requestHandler;

        public ExaminationsUploader(
            IExaminationsUri examinationsUri, 
            IExaminationsRequestCreator requestCreator, 
            IExaminationsRequestHandler requestHandler)
        {
            this.examinationsUri = examinationsUri;
            this.requestCreator = requestCreator;
            this.requestHandler = requestHandler;
        }

        public async Task<string> UploadAsync(DateTime startPeriod)
        {
            var request = requestCreator.CreateBaseRequest(startPeriod);
            request.RequestUri = examinationsUri.BuildUri(1, 1);
            var response = await requestHandler.HandleRequest(request);
            return "";
        }
    }
}
