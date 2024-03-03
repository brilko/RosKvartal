﻿using AutoMapper;
using ParsingDomGosuslugi.Requests.Contracts.Models;

namespace ParsingDomGosuslugi.MapperProfiles
{
    internal class ExaminationProfile: Profile
    {
        public ExaminationProfile() 
        {
            CreateMap<ExaminationModel, ExaminationDto>()
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

        }
    }
}