using RepositoryContracts.Entities;

namespace RepositoryContracts.Intefaces
{
    public interface IUpdateDateRepository : IRepository<UpdateDate>
    {
        Task<DateTime> GetDateOfLastUpdate();
        Task AddDateNowAsync();
    }
}
