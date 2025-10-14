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
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IMedicamentoRepository _repo;
        private readonly IMapper _mapper;

        public MedicamentoService(IMedicamentoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicamentoDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<MedicamentoDto>>(items);
        }

        public async Task<MedicamentoDto?> GetByIdAsync(Guid id)
        {
            var item = await _repo.GetByIdAsync(id);
            return _mapper.Map<MedicamentoDto?>(item);
        }

        public async Task<MedicamentoDto> CreateAsync(MedicamentoCreateDto dto)
        {
            var entity = _mapper.Map<Medicamento>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<MedicamentoDto>(created);
        }

        public async Task<MedicamentoDto> UpdateAsync(Guid id, MedicamentoUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException("Medicamento no encontrado");
            _mapper.Map(dto, entity);
            var updated = await _repo.UpdateAsync(entity);
            return _mapper.Map<MedicamentoDto>(updated);
        }

        public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);
    }
}
