namespace ParsingDomGosuslugi.Requests.Contracts.Interfaces
{
    internal interface IExaminationsRequestCreator
    {
        HttpRequestMessage CreateBaseRequest(DateTime startPeriod);
    }
}
