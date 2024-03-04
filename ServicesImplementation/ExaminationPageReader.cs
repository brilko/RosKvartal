using AutoMapper;
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

        public Task<List<ExaminationDto>> ReadExaminationPage(SearchPageDto page)
        {
            
            throw new NotImplementedException();
        }
    }
}
