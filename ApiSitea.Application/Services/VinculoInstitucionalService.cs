// Application/Services/VinculoInstitucionalService.cs
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using AutoMapper;

namespace ApiSitea.Application.Services
{
    public class VinculoInstitucionalService : IVinculoInstitucionalService
    {
        private readonly IVinculoInstitucionalRepository _repo;
        private readonly IMapper _mapper;

        public VinculoInstitucionalService(IVinculoInstitucionalRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VinculoInstitucionalDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<VinculoInstitucionalDto>>(await _repo.GetAllAsync());

        public async Task<VinculoInstitucionalDto?> GetByIdAsync(Guid id) =>
            _mapper.Map<VinculoInstitucionalDto?>(await _repo.GetByIdAsync(id));

        public async Task<IEnumerable<VinculoInstitucionalDto>> SearchByNameAsync(string term) =>
            _mapper.Map<IEnumerable<VinculoInstitucionalDto>>(await _repo.SearchByNameAsync(term));

        public async Task<VinculoInstitucionalDto> CreateAsync(VinculoInstitucionalCreateDto dto)
        {
            var entity = _mapper.Map<VinculoInstitucional>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<VinculoInstitucionalDto>(created);
        }

        public async Task<VinculoInstitucionalDto> UpdateAsync(Guid id, VinculoInstitucionalUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Diagnóstico no encontrado");

            _mapper.Map(dto, entity);
            var updated = await _repo.UpdateAsync(entity);
            return _mapper.Map<VinculoInstitucionalDto>(updated);
        }

        public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);
    }
}
