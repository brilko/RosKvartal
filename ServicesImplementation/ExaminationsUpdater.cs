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
        private readonly DateTime startDateToUpdate;
        private readonly int batchSize;
        private readonly IMapper mapper;
        private readonly IExaminationRepository examinationRepository;

        public ExaminationsUpdater(
            IExaminationsUploader examinationsUploader,
            PeriodToInitialLoad periodToInitialLoad,
            PeriodBetweenLoads periodBetweenLoads,
            BatchSizeParameter batchSizeParameter,
            IMapper mapper,
            IExaminationRepository examinationRepository)
        {
            this.examinationsUploader = examinationsUploader;
            startDateToInitialize = periodToInitialLoad.GetStartDate();
            startDateToUpdate = periodBetweenLoads.GetStartDate();
            batchSize = batchSizeParameter.Size;
            this.mapper = mapper;
            this.examinationRepository = examinationRepository;
        }

        public async Task Initialize()
        {
            var batchNumber = 0;
            var totalCount = long.MaxValue;
            while (totalCount > batchNumber * batchSize)
            {
                batchNumber++;
                var response = await examinationsUploader
                    .UploadBatchAsync(batchNumber, startDateToInitialize);
                totalCount = response.Total;
                var examinationsDto = mapper.Map<List<ExaminationDto>>(response.Items);
                var examinations = mapper.Map<List<Examination>>(examinationsDto);

                await examinationRepository.AddRangeAsync(examinations);
            }
        }

        public async Task Update() 
        {
            var batchNumber = 0;
            var totalCount = long.MaxValue;
            while (totalCount > batchNumber * batchSize)
            {
                batchNumber++;
                var response = await examinationsUploader.UploadBatchAsync(batchNumber, startDateToUpdate);
                totalCount = response.Total;
                var examinationsDto = mapper.Map<List<ExaminationDto>>(response.Items);
                //TODO:тут
            }
        }


    }
}
