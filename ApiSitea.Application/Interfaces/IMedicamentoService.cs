using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSitea.Application.DTOs;

namespace ApiSitea.Application.Interfaces
{
    public interface IMedicamentoService
    {
        Task<IEnumerable<MedicamentoDto>> GetAllAsync();
        Task<MedicamentoDto?> GetByIdAsync(Guid id);
        Task<MedicamentoDto> CreateAsync(MedicamentoCreateDto dto);
        Task<MedicamentoDto> UpdateAsync(Guid id, MedicamentoUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
