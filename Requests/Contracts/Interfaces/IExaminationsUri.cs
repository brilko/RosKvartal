namespace ParsingDomGosuslugi.Requests.Contracts.Interfaces
{
    internal interface IExaminationsUri
    {
        Uri BuildUri(int pageNumber, int pageSize);
    }
}
