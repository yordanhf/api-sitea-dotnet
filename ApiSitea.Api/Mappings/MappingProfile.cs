    using AutoMapper;
    using ApiSitea.Application.DTOs;
    using ApiSitea.Domain.Entities;

    namespace ApiSitea.Api.Mappings
    {
        public class MappingProfile : Profile
        {
            public MappingProfile() 
            {
                CreateMap<Medicamento, MedicamentoDto>().ReverseMap();
                CreateMap<MedicamentoCreateDto, Medicamento>();
                CreateMap<MedicamentoUpdateDto, Medicamento>();
            }
        }
    }
