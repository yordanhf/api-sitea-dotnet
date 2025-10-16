// Application/Interfaces/IFortalezaService.cs
using ApiSitea.Application.DTOs;

namespace ApiSitea.Application.Interfaces
{
    public interface IFortalezaService
    {
        Task<IEnumerable<FortalezaDto>> GetAllAsync();
        Task<FortalezaDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<FortalezaDto>> SearchByNameAsync(string term);
        Task<FortalezaDto> CreateAsync(FortalezaCreateDto dto);
        Task<FortalezaDto> UpdateAsync(Guid id, FortalezaUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
