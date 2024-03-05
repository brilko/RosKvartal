using ServicesContracts.DTOs;

namespace ServicesContracts.Interfaces
{
    public interface IExaminationsBatchLoader
    {
        Task LoadBatchesAndAct(DateTime startDateTimeToLoad, Func<List<ExaminationDto>, Task> actionWithBatch);
    }
}
