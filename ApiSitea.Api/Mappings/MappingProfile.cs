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

             CreateMap<AntecedentePPP, AntecedentePPPDto>().ReverseMap();
             CreateMap<AntecedentePPPCreateDto, AntecedentePPP>();
             CreateMap<AntecedentePPPDto, AntecedentePPP>();

             CreateMap<Centro, CentroDto>().ReverseMap();
             CreateMap<CentroCreateDto, Centro>();
             CreateMap<CentroUpdateDto, Centro>();

            CreateMap<CClinica, CClinicaDto>().ReverseMap();
            CreateMap<CClinicaCreateDto, CClinica>();
            CreateMap<CClinicaUpdateDto, CClinica>();
        }
        }
    }
