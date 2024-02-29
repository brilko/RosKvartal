using ParsingDomGosuslugi.Requests.Contracts.Interfaces;

namespace ParsingDomGosuslugi.Requests.Implementations
{
    internal class ExaminationsUri: IExaminationsUri
    {
        private readonly string pageNumberParameterName;
        private readonly string pageSizeParameterName;
        private readonly string uri;
        public ExaminationsUri(ExaminationsUriConfigParams uriParams)
        {
            uri = uriParams.ExaminationsUri;
            pageNumberParameterName = uriParams.ExaminationsUriParameterPageNumber;
            pageSizeParameterName = uriParams.ExaminationsUriParametersPageSize;
        }

        public Uri BuildUri(int pageNumber, int pageSize)
        {
            var buildedTextUri = uri
                .Replace(pageNumberParameterName, pageNumber.ToString())
                .Replace(pageSizeParameterName, pageSize.ToString());
            var buildedUri = new Uri(buildedTextUri);
            return buildedUri;
        }
    }
}
