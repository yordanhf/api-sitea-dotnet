// Application/Interfaces/ITipoInterconsultaService.cs
using ApiSitea.Application.DTOs;

namespace ApiSitea.Application.Interfaces
{
    public interface ITipoInterconsultaService
    {
        Task<IEnumerable<TipoInterconsultaDto>> GetAllAsync();
        Task<TipoInterconsultaDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<TipoInterconsultaDto>> SearchByNameAsync(string term);
        Task<TipoInterconsultaDto> CreateAsync(TipoInterconsultaCreateDto dto);
        Task<TipoInterconsultaDto> UpdateAsync(Guid id, TipoInterconsultaUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
