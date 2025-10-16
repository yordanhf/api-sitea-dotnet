// Application/Interfaces/IVinculoInstitucionalService.cs
using ApiSitea.Application.DTOs;

namespace ApiSitea.Application.Interfaces
{
    public interface IVinculoInstitucionalService
    {
        Task<IEnumerable<VinculoInstitucionalDto>> GetAllAsync();
        Task<VinculoInstitucionalDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<VinculoInstitucionalDto>> SearchByNameAsync(string term);
        Task<VinculoInstitucionalDto> CreateAsync(VinculoInstitucionalCreateDto dto);
        Task<VinculoInstitucionalDto> UpdateAsync(Guid id, VinculoInstitucionalUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
