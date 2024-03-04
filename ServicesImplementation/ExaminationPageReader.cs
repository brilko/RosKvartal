using AutoMapper;
using RepositoryContracts;
using RepositoryContracts.Intefaces;
using ServicesContracts.DTOs;
using ServicesContracts.Interfaces;

namespace ServicesImplementation
{
    public class ExaminationPageReader : IExaminationPageReader
    {
        private readonly IExaminationRepository examinationRepository;
        private readonly IMapper mapper;

        public ExaminationPageReader(IExaminationRepository examinationRepository, IMapper mapper)
        {
            this.examinationRepository = examinationRepository;
            this.mapper = mapper;
        }

        public async Task<List<ExaminationDto>> ReadExaminationPage(SearchPageDto page)
        {
            var repositoryPage = mapper.Map<SearchPage>(page);
            var examinationEntities = await examinationRepository.ReadPageAsync(repositoryPage);
            var examinationDtos = mapper.Map<List<ExaminationDto>>(examinationEntities);
            return examinationDtos;
        }
    }
}
