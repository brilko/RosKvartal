using ServicesContracts.DTOs;

namespace ServicesContracts.Interfaces
{
    public interface IExaminationPageReader
    {
        Task<List<ExaminationDto>> ReadExaminationPage(SearchPageDto page);
    }
}
