// File: Application/Interfaces/ICClinicaService.cs
using ApiSitea.Application.DTOs;

namespace ApiSitea.Application.Interfaces
{
    public interface ICClinicaService
    {
        Task<IEnumerable<CClinicaDto>> GetAllAsync();
        Task<CClinicaDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<CClinicaDto>> SearchByNameAsync(string term);
        Task<CClinicaDto> CreateAsync(CClinicaCreateDto dto);
        Task<CClinicaDto> UpdateAsync(Guid id, CClinicaUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
