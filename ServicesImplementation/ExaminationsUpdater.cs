using AutoMapper;
using ConfigurationParameters;
using RequestsContracts.Interfaces;
using ServicesContracts.DTOs;
using ServicesContracts.Interfaces;

namespace ServicesImplementation
{
    public class ExaminationsUpdater : IExaminationsUpdater
    {
        private readonly IExaminationsUploader examinationsUploader;
        private readonly int batchSize;
        private readonly IMapper mapper;

        public ExaminationsUpdater(
            IExaminationsUploader examinationsUploader,
            BatchSizeParameter batchSizeParameter,
            IMapper mapper)
        {
            this.examinationsUploader = examinationsUploader;
            batchSize = batchSizeParameter.Size;
            this.mapper = mapper;
        }

        public async void Update()
        {
            var batchNumber = 0;
            var totalCount = long.MaxValue;
            while (totalCount > batchNumber * batchSize)
            {
                batchNumber++;
                var response = await examinationsUploader.UploadBatchAsync(batchNumber);
                totalCount = response.Total;
                var examinationsDto = mapper.Map<List<ExaminationDto>>(response.Items);

            }
        }
    }
}
