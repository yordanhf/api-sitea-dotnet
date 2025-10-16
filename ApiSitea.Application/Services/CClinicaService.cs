// File: Application/Services/CClinicaService.cs
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using AutoMapper;

namespace ApiSitea.Application.Services
{
    public class CClinicaService : ICClinicaService
    {
        private readonly ICClinicaRepository _repo;
        private readonly IMapper _mapper;

        public CClinicaService(ICClinicaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CClinicaDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CClinicaDto>>(items);
        }

        public async Task<CClinicaDto?> GetByIdAsync(Guid id)
        {
            var item = await _repo.GetByIdAsync(id);
            return _mapper.Map<CClinicaDto?>(item);
        }

        public async Task<IEnumerable<CClinicaDto>> SearchByNameAsync(string term)
        {
            var items = await _repo.SearchByNameAsync(term);
            return _mapper.Map<IEnumerable<CClinicaDto>>(items);
        }

        public async Task<CClinicaDto> CreateAsync(CClinicaCreateDto dto)
        {
            var entity = _mapper.Map<CClinica>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<CClinicaDto>(created);
        }

        public async Task<CClinicaDto> UpdateAsync(Guid id, CClinicaUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException("Característica clínica no encontrada");
            _mapper.Map(dto, entity);
            var updated = await _repo.UpdateAsync(entity);
            return _mapper.Map<CClinicaDto>(updated);
        }

        public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);
    }
}
