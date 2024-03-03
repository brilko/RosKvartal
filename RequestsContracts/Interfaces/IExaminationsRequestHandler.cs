using DataTransferObjects;

namespace RequestsContracts.Interfaces
{
    public interface IExaminationsRequestHandler
    {
        Task<ExaminationResponseDto?> HandleRequest(HttpRequestMessage request);
    }
}
