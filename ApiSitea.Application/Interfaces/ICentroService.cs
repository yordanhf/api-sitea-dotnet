using ApiSitea.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSitea.Application.Interfaces
{
    public interface ICentroService
    {
        Task<IEnumerable<CentroDto>> GetAllAsync();
        Task<CentroDto?> GetByIdAsync(Guid id);
        Task<CentroDto> CreateAsync(CentroCreateDto dto);
        Task<CentroDto> UpdateAsync(Guid id, CentroUpdateDto dto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<CentroDto>> SearchByNameAsync(string nombre);
    }
}