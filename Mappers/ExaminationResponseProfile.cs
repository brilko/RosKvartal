using AutoMapper;
using RequestsContracts.Models;
using ServicesContracts.DTOs;

namespace Mappers
{
    public class ExaminationResponseProfile : Profile
    {
        public ExaminationResponseProfile()
        {
            CreateMap<ExaminationsResponseModel, ExaminationResponseDto>();
        }
    }
}
