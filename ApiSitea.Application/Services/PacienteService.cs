using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ApiSitea.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<PacienteCreateDto> _createValidator;
        private readonly IValidator<PacienteUpdateDto> _updateValidator;

        public PacienteService(
            IPacienteRepository pacienteRepository,
            IMapper mapper,
            IValidator<PacienteCreateDto> createValidator,
            IValidator<PacienteUpdateDto> updateValidator)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<PacienteDto>> GetAllAsync()
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PacienteDto>>(pacientes);
        }

        public async Task<PacienteDto?> GetByIdAsync(Guid id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            return paciente != null ? _mapper.Map<PacienteDto>(paciente) : null;
        }

        public async Task<PacienteDto> CreateAsync(PacienteCreateDto pacienteDto)
        {
            await _createValidator.ValidateAndThrowAsync(pacienteDto);

            var paciente = _mapper.Map<Paciente>(pacienteDto);
            await _pacienteRepository.AddAsync(paciente);

            return _mapper.Map<PacienteDto>(paciente);
        }

        public async Task<PacienteDto> UpdateAsync(PacienteUpdateDto pacienteDto)
        {
            await _updateValidator.ValidateAndThrowAsync(pacienteDto);

            var existingPaciente = await _pacienteRepository.GetByIdAsync(new Guid(pacienteDto.Id.ToString()));
            if (existingPaciente == null)
                throw new KeyNotFoundException($"Paciente con ID {pacienteDto.Id} no encontrado.");

            var paciente = _mapper.Map<Paciente>(pacienteDto);
            await _pacienteRepository.UpdateAsync(paciente);

            return _mapper.Map<PacienteDto>(paciente);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _pacienteRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PacienteDto>> SearchAsync(string? nombre, string? apellidos, string? ci)
        {
            var pacientes = await _pacienteRepository.SearchAsync(nombre, apellidos, ci);
            return _mapper.Map<IEnumerable<PacienteDto>>(pacientes);
        }
    }
}