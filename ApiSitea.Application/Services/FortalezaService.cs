// Application/Services/FortalezaService.cs
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using AutoMapper;

namespace ApiSitea.Application.Services
{
    public class FortalezaService : IFortalezaService
    {
        private readonly IFortalezaRepository _repo;
        private readonly IMapper _mapper;

        public FortalezaService(IFortalezaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FortalezaDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<FortalezaDto>>(await _repo.GetAllAsync());

        public async Task<FortalezaDto?> GetByIdAsync(Guid id) =>
            _mapper.Map<FortalezaDto?>(await _repo.GetByIdAsync(id));

        public async Task<IEnumerable<FortalezaDto>> SearchByNameAsync(string term) =>
            _mapper.Map<IEnumerable<FortalezaDto>>(await _repo.SearchByNameAsync(term));

        public async Task<FortalezaDto> CreateAsync(FortalezaCreateDto dto)
        {
            var entity = _mapper.Map<Fortaleza>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<FortalezaDto>(created);
        }

        public async Task<FortalezaDto> UpdateAsync(Guid id, FortalezaUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Diagnóstico no encontrado");

            _mapper.Map(dto, entity);
            var updated = await _repo.UpdateAsync(entity);
            return _mapper.Map<FortalezaDto>(updated);
        }

        public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);
    }
}
