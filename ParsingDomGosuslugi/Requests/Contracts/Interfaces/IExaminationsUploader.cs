namespace ParsingDomGosuslugi.Requests.Contracts.Interfaces
{
    internal interface IExaminationsUploader
    {
        Task<string> UploadAsync(DateTime startPeriod);
    }
}
