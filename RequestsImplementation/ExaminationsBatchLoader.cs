using AutoMapper;
using ConfigurationParameters;
using RepositoryContracts.Entities;
using RequestsContracts.Interfaces;
using ServicesContracts.DTOs;
using ServicesContracts.Interfaces;

namespace ServicesImplementation
{
    public class ExaminationsBatchLoader : IExaminationsBatchLoader
    {
        private readonly IExaminationsUploader examinationsUploader;
        private readonly int batchSize;
        private readonly IMapper mapper;

        public ExaminationsBatchLoader(
            IExaminationsUploader examinationsUploader,
            BatchSizeParameter batchSizeParameter,
            IMapper mapper)
        {
            this.examinationsUploader = examinationsUploader;
            batchSize = batchSizeParameter.Size;
            this.mapper = mapper;
        }

        public async Task LoadBatchesAndAct(
            DateTime startDateTimeToLoad, Func<List<ExaminationDto>, Task> actionWithBatch)
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

                await actionWithBatch(examinationsDto);
            }
        }
    }
}
