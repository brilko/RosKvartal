using ConfigurationParameters;
using RepositoryContracts.Intefaces;
using ServicesContracts.Interfaces;

namespace ServicesImplementation
{
    public class ExaminationsUpdater : IExaminationsUpdater
    {
        private readonly ILoadBatchesAndActAdapter loadBatchesAndActAdapter;
        private readonly IExaminationRepository examinationRepository;
        private readonly IUpdateDateRepository updateDateRepository;
        private readonly LoadPeriodForUpdate loadPeriodForUpdate;

        public ExaminationsUpdater(
            IExaminationRepository examinationRepository,
            ILoadBatchesAndActAdapter loadBatchesAndActAdapter,
            IUpdateDateRepository updateDateRepository,
            LoadPeriodForUpdate loadPeriodForUpdate)
        {
            this.examinationRepository = examinationRepository;
            this.loadBatchesAndActAdapter = loadBatchesAndActAdapter;
            this.updateDateRepository = updateDateRepository;
            this.loadPeriodForUpdate = loadPeriodForUpdate;
        }

        public async Task Update()
        {
            //Скачивание происходит относительно полседней даты обновления
            var lastUpdate = await updateDateRepository.GetDateOfLastUpdate();
            await updateDateRepository.AddDateNowAsync();
            var dateTimeToLoad = loadPeriodForUpdate.GetStartDate(lastUpdate);
            //Так как дата проверки моет быть запланирована на будущее,
            //то в инициализированных проверках могут быть те проверки, которые выдаёт гис жкх,
            //при новых запросах. Причём гис жкх может выдавать те проверки, начало даты проверки которых,
            //стоит раншьше запрошенной даты.
            var existExaminations = await examinationRepository
                .GetIdsStartNotPreviousAsync(dateTimeToLoad.AddDays(-1));
            await loadBatchesAndActAdapter.LoadBatchesAndAct(dateTimeToLoad, async examinations => 
            {
                var examinationsToAdd = examinations
                    .Where(e => !existExaminations.Contains(e.Id))
                    .ToList();
                await examinationRepository.AddRangeAsync(examinationsToAdd);
            });
        }
    }
}
