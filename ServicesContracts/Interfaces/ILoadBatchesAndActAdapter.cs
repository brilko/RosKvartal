using RepositoryContracts.Entities;

namespace ServicesContracts.Interfaces
{
    public interface ILoadBatchesAndActAdapter
    {
        Task LoadBatchesAndAct(DateTime startDateTimeToLoad, Func<List<Examination>, Task> actionWithBatch);
    }
}
