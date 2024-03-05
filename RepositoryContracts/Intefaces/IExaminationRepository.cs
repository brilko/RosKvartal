using RepositoryContracts.Entities;

namespace RepositoryContracts.Intefaces
{
    public interface IExaminationRepository : IRepository<Examination>
    {
        Task<List<Guid>> GetIdsStartNotPreviousAsync(DateTime date);
    }
}
