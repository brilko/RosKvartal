namespace RepositoryContracts.Intefaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void AddRangeAsync(List<T> entities);
        Task<List<T>> ReadPageAsync(SearchPage page);
    }
}
