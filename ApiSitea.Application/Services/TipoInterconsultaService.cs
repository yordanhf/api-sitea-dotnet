// Application/Services/TipoInterconsultaService.cs
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using AutoMapper;

namespace ApiSitea.Application.Services
{
    public class TipoInterconsultaService : ITipoInterconsultaService
    {
        private readonly ITipoInterconsultaRepository _repo;
        private readonly IMapper _mapper;

        public TipoInterconsultaService(ITipoInterconsultaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoInterconsultaDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<TipoInterconsultaDto>>(await _repo.GetAllAsync());

        public async Task<TipoInterconsultaDto?> GetByIdAsync(Guid id) =>
            _mapper.Map<TipoInterconsultaDto?>(await _repo.GetByIdAsync(id));

        public async Task<IEnumerable<TipoInterconsultaDto>> SearchByNameAsync(string term) =>
            _mapper.Map<IEnumerable<TipoInterconsultaDto>>(await _repo.SearchByNameAsync(term));

        public async Task<TipoInterconsultaDto> CreateAsync(TipoInterconsultaCreateDto dto)
        {
            var entity = _mapper.Map<TipoInterconsulta>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<TipoInterconsultaDto>(created);
        }

        public async Task<TipoInterconsultaDto> UpdateAsync(Guid id, TipoInterconsultaUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Diagnóstico no encontrado");

            _mapper.Map(dto, entity);
            var updated = await _repo.UpdateAsync(entity);
            return _mapper.Map<TipoInterconsultaDto>(updated);
        }

        public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);
    }
}
