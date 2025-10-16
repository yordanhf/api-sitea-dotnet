// Application/Interfaces/ITipoExamenService.cs
using ApiSitea.Application.DTOs;

namespace ApiSitea.Application.Interfaces
{
    public interface ITipoExamenService
    {
        Task<IEnumerable<TipoExamenDto>> GetAllAsync();
        Task<TipoExamenDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<TipoExamenDto>> SearchByNameAsync(string term);
        Task<TipoExamenDto> CreateAsync(TipoExamenCreateDto dto);
        Task<TipoExamenDto> UpdateAsync(Guid id, TipoExamenUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
