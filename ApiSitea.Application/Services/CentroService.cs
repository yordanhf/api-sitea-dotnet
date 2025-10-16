using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using AutoMapper;

namespace ApiSitea.Application.Services
{
    public class CentroService : ICentroService
    {
        private readonly ICentroRepository _repo;
        private readonly IMapper _mapper;

        public CentroService(ICentroRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CentroDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CentroDto>>(items);
        }

        public async Task<CentroDto?> GetByIdAsync(Guid id)
        {
            var item = await _repo.GetByIdAsync(id);
            return _mapper.Map<CentroDto?>(item);
        }

        public async Task<CentroDto> CreateAsync(CentroCreateDto dto)
        {
            var entity = _mapper.Map<Centro>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<CentroDto>(created);
        }

        public async Task<CentroDto> UpdateAsync(Guid id, CentroUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Centro no encontrado");

            _mapper.Map(dto, entity);
            var updated = await _repo.UpdateAsync(entity);
            return _mapper.Map<CentroDto>(updated);
        }

        public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

        public async Task<IEnumerable<CentroDto>> SearchByNameAsync(string nombre)
        {
            var items = await _repo.SearchByNameAsync(nombre);
            return _mapper.Map<IEnumerable<CentroDto>>(items);
        }
    }
}