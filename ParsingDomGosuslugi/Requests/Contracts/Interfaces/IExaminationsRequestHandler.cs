using ParsingDomGosuslugi.Requests.Contracts.Models;

namespace ParsingDomGosuslugi.Requests.Contracts.Interfaces
{
    internal interface IExaminationsRequestHandler
    {
        Task<ExaminationResponseDto?> HandleRequest(HttpRequestMessage request);
    }
}
