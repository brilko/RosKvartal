using AutoMapper;
using ParsingDomGosuslugi.Requests.Contracts.Models;

namespace ParsingDomGosuslugi.MapperProfiles
{
    internal class ExaminationResponseProfile: Profile
    {
        public ExaminationResponseProfile() 
        {
            CreateMap<ExaminationsResponseModel, ExaminationResponseDto>();
        }
    }
}
