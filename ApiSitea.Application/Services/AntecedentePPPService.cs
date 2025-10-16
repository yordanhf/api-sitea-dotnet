using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using AutoMapper;

namespace ApiSitea.Application.Services
{
    public class AntecedentePPPService : IAntecedentePPPService
    {
        private readonly IAntecedentePPPRepository _repo;
        private readonly IMapper _mapper;

        public AntecedentePPPService(IAntecedentePPPRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AntecedentePPPDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<AntecedentePPPDto>>(items);
        }

        public async Task<AntecedentePPPDto?> GetByIdAsync(Guid id)
        {
            var item = await _repo.GetByIdAsync(id);
            return _mapper.Map<AntecedentePPPDto?>(item);
        }

        public async Task<AntecedentePPPDto> CreateAsync(AntecedentePPPCreateDto dto)
        {
            var entity = _mapper.Map<AntecedentePPP>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<AntecedentePPPDto>(created);
        }

        public async Task<AntecedentePPPDto> UpdateAsync(Guid id, AntecedentePPPDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException("Antecedente no encontrado");
            _mapper.Map(dto, entity);
            var updated = await _repo.UpdateAsync(entity);
            return _mapper.Map<AntecedentePPPDto>(updated);
        }

        public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

        // 🔍 Búsqueda parcial
        public async Task<IEnumerable<AntecedentePPPDto>> SearchByNameAsync(string searchTerm)
        {
            var items = await _repo.SearchByNameAsync(searchTerm);
            return _mapper.Map<IEnumerable<AntecedentePPPDto>>(items);
        }
    }
}
