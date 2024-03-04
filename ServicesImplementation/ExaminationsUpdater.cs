using AutoMapper;
using ConfigurationParameters;
using RepositoryContracts.Entities;
using RepositoryContracts.Intefaces;
using RequestsContracts.Interfaces;
using ServicesContracts.DTOs;
using ServicesContracts.Interfaces;

namespace ServicesImplementation
{
    public class ExaminationsUpdater : IExaminationsUpdater
    {
        private readonly IExaminationsUploader examinationsUploader;
        private readonly DateTime startDateToInitialize;
        private readonly int batchSize;
        private readonly IMapper mapper;
        private readonly IExaminationRepository examinationRepository;

        public ExaminationsUpdater(
            IExaminationsUploader examinationsUploader,
            PeriodToInitialLoad periodToInitialLoad,
            BatchSizeParameter batchSizeParameter,
            IMapper mapper,
            IExaminationRepository examinationRepository)
        {
            this.examinationsUploader = examinationsUploader;
            startDateToInitialize = periodToInitialLoad.GetStartDate();
            batchSize = batchSizeParameter.Size;
            this.mapper = mapper;
            this.examinationRepository = examinationRepository;
        }

        public async Task Initialize()
        {
            await LoadBatchesAndAct(startDateToInitialize, async examinations => 
            {
                await examinationRepository.AddRangeAsync(examinations);
            });
        }

        public async Task Update()
        {
            var lastExaminationDate = await examinationRepository.GetDateOfLastUploadedExamination();
            var lastExaminationsIds = await examinationRepository
                .GetExaminationsIdsWithDate(lastExaminationDate);
            await LoadBatchesAndAct(lastExaminationDate, async examinations => 
            {
                var newExaminations = examinations
                    .Where(e => !lastExaminationsIds.Contains(e.Id))
                    .ToList();
                await examinationRepository.AddRangeAsync(newExaminations);
            });
        }

        private async Task LoadBatchesAndAct(
            DateTime startDateTimeToLoad, Action<List<Examination>> actionWithBatch) 
        {
            var batchNumber = 0;
            var totalCount = long.MaxValue;
            while (totalCount > batchNumber * batchSize)
            {
                batchNumber++;
                var response = await examinationsUploader
                    .UploadBatchAsync(batchNumber, startDateTimeToLoad);
                totalCount = response.Total;
                var examinationsDto = mapper.Map<List<ExaminationDto>>(response.Items);
                var examinations = mapper.Map<List<Examination>>(examinationsDto);

                actionWithBatch(examinations);
            }
        }
    }
}
