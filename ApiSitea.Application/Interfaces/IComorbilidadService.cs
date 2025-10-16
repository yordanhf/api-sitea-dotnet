// File: Application/Interfaces/IComorbilidadService.cs
using ApiSitea.Application.DTOs;

namespace ApiSitea.Application.Interfaces
{
    public interface IComorbilidadService
    {
        Task<IEnumerable<ComorbilidadDto>> GetAllAsync();
        Task<ComorbilidadDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<ComorbilidadDto>> SearchByNameAsync(string term);
        Task<ComorbilidadDto> CreateAsync(ComorbilidadCreateDto dto);
        Task<ComorbilidadDto> UpdateAsync(Guid id, ComorbilidadUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
