using AutoMapper;
using ConfigurationParameters;
using RepositoryContracts.Entities;
using RepositoryContracts.Intefaces;
using ServicesContracts.Interfaces;

namespace ServicesImplementation
{
    public class LoadBatchesAndActAdapter : ILoadBatchesAndActAdapter
    {
        private readonly IExaminationsBatchLoader examinationsBatchLoader;
        private readonly IMapper mapper;

        public LoadBatchesAndActAdapter(
            IMapper mapper,
            IExaminationsBatchLoader examinationsBatchLoader)
        {
            this.mapper = mapper;
            this.examinationsBatchLoader = examinationsBatchLoader;
        }
        public async Task LoadBatchesAndAct(
            DateTime startDateTimeToLoad, Func<List<Examination>, Task> actionWithBatch)
        {
            await examinationsBatchLoader.LoadBatchesAndAct(startDateTimeToLoad, async examinationsDto =>
            {
                var examinations = mapper.Map<List<Examination>>(examinationsDto);
                await actionWithBatch(examinations);
            });
        }
    }
}
