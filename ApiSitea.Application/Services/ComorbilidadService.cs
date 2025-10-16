// File: Application/Services/ComorbilidadService.cs
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using AutoMapper;

namespace ApiSitea.Application.Services
{
    public class ComorbilidadService : IComorbilidadService
    {
        private readonly IComorbilidadRepository _repo;
        private readonly IMapper _mapper;

        public ComorbilidadService(IComorbilidadRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ComorbilidadDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ComorbilidadDto>>(items);
        }

        public async Task<ComorbilidadDto?> GetByIdAsync(Guid id)
        {
            var item = await _repo.GetByIdAsync(id);
            return _mapper.Map<ComorbilidadDto?>(item);
        }

        public async Task<IEnumerable<ComorbilidadDto>> SearchByNameAsync(string term)
        {
            var items = await _repo.SearchByNameAsync(term);
            return _mapper.Map<IEnumerable<ComorbilidadDto>>(items);
        }

        public async Task<ComorbilidadDto> CreateAsync(ComorbilidadCreateDto dto)
        {
            var entity = _mapper.Map<Comorbilidad>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<ComorbilidadDto>(created);
        }

        public async Task<ComorbilidadDto> UpdateAsync(Guid id, ComorbilidadUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Comorbilidad no encontrada");

            _mapper.Map(dto, entity);
            var updated = await _repo.UpdateAsync(entity);
            return _mapper.Map<ComorbilidadDto>(updated);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
