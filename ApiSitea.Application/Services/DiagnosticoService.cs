// Application/Services/DiagnosticoService.cs
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using AutoMapper;

namespace ApiSitea.Application.Services
{
    public class DiagnosticoService : IDiagnosticoService
    {
        private readonly IDiagnosticoRepository _repo;
        private readonly IMapper _mapper;

        public DiagnosticoService(IDiagnosticoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DiagnosticoDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<DiagnosticoDto>>(await _repo.GetAllAsync());

        public async Task<DiagnosticoDto?> GetByIdAsync(Guid id) =>
            _mapper.Map<DiagnosticoDto?>(await _repo.GetByIdAsync(id));

        public async Task<IEnumerable<DiagnosticoDto>> SearchByNameAsync(string term) =>
            _mapper.Map<IEnumerable<DiagnosticoDto>>(await _repo.SearchByNameAsync(term));

        public async Task<DiagnosticoDto> CreateAsync(DiagnosticoCreateDto dto)
        {
            var entity = _mapper.Map<Diagnostico>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<DiagnosticoDto>(created);
        }

        public async Task<DiagnosticoDto> UpdateAsync(Guid id, DiagnosticoUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Diagnóstico no encontrado");

            _mapper.Map(dto, entity);
            var updated = await _repo.UpdateAsync(entity);
            return _mapper.Map<DiagnosticoDto>(updated);
        }

        public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);
    }
}
