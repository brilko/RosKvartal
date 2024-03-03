using RequestsContracts.Models;

namespace RequestsContracts.Interfaces
{
    public interface IExaminationsUploader
    {
        Task<ExaminationsResponseModel> UploadBatchAsync(int batchNumber);
    }
}
