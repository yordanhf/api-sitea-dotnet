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

            CreateMap<Comorbilidad, ComorbilidadDto>().ReverseMap();
            CreateMap<ComorbilidadCreateDto, Comorbilidad>();
            CreateMap<ComorbilidadUpdateDto, Comorbilidad>();

            CreateMap<Diagnostico, DiagnosticoDto>().ReverseMap();
            CreateMap<DiagnosticoCreateDto, Diagnostico>();
            CreateMap<DiagnosticoUpdateDto, Diagnostico>();

            CreateMap<Fortaleza, FortalezaDto>().ReverseMap();
            CreateMap<FortalezaCreateDto, Fortaleza>();
            CreateMap<FortalezaUpdateDto, Fortaleza>();

            CreateMap<TipoInterconsulta, TipoInterconsultaDto>().ReverseMap();
            CreateMap<TipoInterconsultaCreateDto, TipoInterconsulta>();
            CreateMap<TipoInterconsultaUpdateDto, TipoInterconsulta>();

            CreateMap<TipoExamen, TipoExamenDto>().ReverseMap();
            CreateMap<TipoExamenCreateDto, TipoExamen>();
            CreateMap<TipoExamenUpdateDto, TipoExamen>();

            CreateMap<VinculoInstitucional, VinculoInstitucionalDto>().ReverseMap();
            CreateMap<VinculoInstitucionalCreateDto, VinculoInstitucional>();
            CreateMap<VinculoInstitucionalUpdateDto, VinculoInstitucional>();         

            CreateMap<Paciente, PacienteDto>()
               .ForMember(dest => dest.ProvinciaNombre, opt => opt.MapFrom(src => src.Provincia.Nombre))
               .ForMember(dest => dest.MunicipioNombre, opt => opt.MapFrom(src => src.Municipio.Nombre))
               .ForMember(dest => dest.MunicipioNombre, opt => opt.MapFrom(src => src.Municipio.Nombre))
               .ForMember(dest => dest.CentroNombre, opt => opt.MapFrom(src => src.Centro.Nombre))
               .ForMember(dest => dest.DiagnosticoNombre, opt => opt.MapFrom(src => src.Diagnostico.Nombre))
               .ForMember(dest => dest.VinculoInstitucionalNombre, opt => opt.MapFrom(src => src.VinculoInstitucional.Nombre));

            CreateMap<PacienteCreateDto, Paciente>();
            CreateMap<PacienteUpdateDto, Paciente>();

        }
    }
    }
