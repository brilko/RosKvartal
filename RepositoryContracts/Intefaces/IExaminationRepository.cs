using RepositoryContracts.Entities;

namespace RepositoryContracts.Intefaces
{
    public interface IExaminationRepository : IRepository<Examination>
    {
        Task<DateTime> GetDateOfLastUploadedExamination();
        Task<List<Guid>> GetExaminationsIdsWithDate(DateTime date);
    }
}
