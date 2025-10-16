// Application/Interfaces/IDiagnosticoService.cs
using ApiSitea.Application.DTOs;

namespace ApiSitea.Application.Interfaces
{
    public interface IDiagnosticoService
    {
        Task<IEnumerable<DiagnosticoDto>> GetAllAsync();
        Task<DiagnosticoDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<DiagnosticoDto>> SearchByNameAsync(string term);
        Task<DiagnosticoDto> CreateAsync(DiagnosticoCreateDto dto);
        Task<DiagnosticoDto> UpdateAsync(Guid id, DiagnosticoUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
