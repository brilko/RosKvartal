using AutoMapper;
using ConfigurationParameters;
using RepositoryContracts.Intefaces;
using ServicesContracts.Interfaces;

namespace ServicesImplementation
{
    public class ExaminationsInitializer : IExaminationsInitializer
    {
        private readonly ILoadBatchesAndActAdapter loadBatchesAndActAdapter;
        private readonly DateTime startDateToInitialize;
        private readonly IExaminationRepository examinationRepository;
        private readonly IUpdateDateRepository updateDateRepository;

        public ExaminationsInitializer(
            LoadPeriodForInitial periodToInitialLoad,
            IExaminationRepository examinationRepository,
            ILoadBatchesAndActAdapter loadBatchesAndActAdapter,
            IUpdateDateRepository updateDateRepository)
        {
            startDateToInitialize = periodToInitialLoad.GetStartDate();
            this.examinationRepository = examinationRepository;
            this.loadBatchesAndActAdapter = loadBatchesAndActAdapter;
            this.updateDateRepository = updateDateRepository;
        }
        public async Task Initialize()
        {
            await updateDateRepository.AddDateNowAsync();
            await loadBatchesAndActAdapter.LoadBatchesAndAct(startDateToInitialize, async examinations =>
            {
                await examinationRepository.AddRangeAsync(examinations);
            });
        }
    }
}
