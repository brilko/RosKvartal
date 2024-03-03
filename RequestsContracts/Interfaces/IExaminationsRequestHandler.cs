using RequestsContracts.Models;

namespace RequestsContracts.Interfaces
{
    public interface IExaminationsRequestHandler
    {
        Task<ExaminationsResponseModel?> HandleRequest(HttpRequestMessage request);
    }
}
