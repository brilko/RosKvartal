using AutoMapper;
using DataTransferObjects;
using RequestsContracts.Models;

namespace ParsingDomGosuslugi.MapperProfiles
{
    public class ExaminationResponseProfile: Profile
    {
        public ExaminationResponseProfile() 
        {
            CreateMap<ExaminationsResponseModel, ExaminationResponseDto>();
        }
    }
}
