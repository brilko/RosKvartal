namespace ParsingDomGosuslugi.Requests.Contracts.Interfaces
{
    internal interface IExaminationsRequestHandler
    {
        Task<string> HandleRequest(HttpRequestMessage request);
    }
}
