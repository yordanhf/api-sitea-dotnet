// Application/Services/TipoExamenService.cs
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using AutoMapper;

namespace ApiSitea.Application.Services
{
    public class TipoExamenService : ITipoExamenService
    {
        private readonly ITipoExamenRepository _repo;
        private readonly IMapper _mapper;

        public TipoExamenService(ITipoExamenRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoExamenDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<TipoExamenDto>>(await _repo.GetAllAsync());

        public async Task<TipoExamenDto?> GetByIdAsync(Guid id) =>
            _mapper.Map<TipoExamenDto?>(await _repo.GetByIdAsync(id));

        public async Task<IEnumerable<TipoExamenDto>> SearchByNameAsync(string term) =>
            _mapper.Map<IEnumerable<TipoExamenDto>>(await _repo.SearchByNameAsync(term));

        public async Task<TipoExamenDto> CreateAsync(TipoExamenCreateDto dto)
        {
            var entity = _mapper.Map<TipoExamen>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<TipoExamenDto>(created);
        }

        public async Task<TipoExamenDto> UpdateAsync(Guid id, TipoExamenUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Diagnóstico no encontrado");

            _mapper.Map(dto, entity);
            var updated = await _repo.UpdateAsync(entity);
            return _mapper.Map<TipoExamenDto>(updated);
        }

        public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);
    }
}
