using AutoMapper;
using Mappers.MappingUtils;
using RepositoryContracts.Entities;
using RequestsContracts.Models;
using ServicesContracts.DTOs;
using WebApiModels;

namespace Mappers
{
    public class ExaminationProfile : Profile
    {
        public ExaminationProfile()
        {
            CreateMap<ExaminationRequestModel, ExaminationDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Guid)))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Parse(src.From)))
                .ForMember(dest => dest.OrganizationFullName, opt => opt.MapFrom(
                    src => src
                        .Subject
                        .OrganizationInfoEnriched
                        .RegistryOrganizationCommonDetailWithNsi
                        .FullName))
                .ForMember(dest => dest.OrganizationOgrn, opt => opt.MapFrom(
                    src => src
                        .Subject
                        .OrganizationInfoEnriched
                        .RegistryOrganizationCommonDetailWithNsi
                        .Ogrn))
                .ForMember(src => src.ExaminationResult, opt => opt.MapFrom(src =>
                    ExaminationResultsTranslator.BoolToRusSentense(src.HasOffence)))
                .ForMember(src => src.ExaminationStatus, opt => opt.MapFrom(src =>
                    ExaminationCompletionStatusTranslator.EngToRus[src.ExaminationCompletionStatus]));

            CreateMap<ExaminationDto, Examination>()
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(_ => false))
                .ForMember(dest => dest.ExaminationResult, opt => opt.Ignore())
                .ForMember(dest => dest.ExaminationResultId, opt => opt.MapFrom(
                    src => ExaminationResults.FindByName(src.ExaminationResult).Id))
                .ForMember(dest => dest.ExaminationStatus, opt => opt.Ignore())
                .ForMember(dest => dest.ExaminationStatusId, opt => opt.MapFrom(
                    src => ExaminationStatuses.FindByName(src.ExaminationStatus).Id));

            CreateMap<Examination, ExaminationDto>()
                .ForMember(dest => dest.ExaminationResult, opt => opt.MapFrom(src =>
                    ExaminationResults.FindById(src.ExaminationResultId).Name))
                .ForMember(dest => dest.ExaminationStatus, opt => opt.MapFrom(src =>
                    ExaminationStatuses.FindById(src.ExaminationStatusId).Name));

            CreateMap<ExaminationDto, ExaminationGetPageModel>();
        }
    }
}
