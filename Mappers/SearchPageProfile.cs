using AutoMapper;
using RepositoryContracts;
using ServicesContracts.DTOs;
using WebApi.Models;

namespace Mappers
{
    public class SearchPageProfile : Profile
    {
        public SearchPageProfile() 
        {
            CreateMap<SearchPageDto, SearchPage>().ReverseMap();
            CreateMap<SearchPageModel, SearchPageDto>().ReverseMap();
        }
    }
}
