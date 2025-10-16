using ApiSitea.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSitea.Application.Interfaces
{
    public interface IAntecedentePPPService
    {
        Task<IEnumerable<AntecedentePPPDto>> GetAllAsync();
        Task<AntecedentePPPDto?> GetByIdAsync(Guid id);
        Task<AntecedentePPPDto> CreateAsync(AntecedentePPPCreateDto dto);
        Task<AntecedentePPPDto> UpdateAsync(Guid id, AntecedentePPPDto dto);
        Task DeleteAsync(Guid id);

        // 🔍 Búsqueda parcial por nombre
        Task<IEnumerable<AntecedentePPPDto>> SearchByNameAsync(string searchTerm);
    }
}
