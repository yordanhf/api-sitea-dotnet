// Domain/Interfaces/IVinculoInstitucionalRepository.cs
using ApiSitea.Domain.Entities;

namespace ApiSitea.Domain.Interfaces
{
    public interface IVinculoInstitucionalRepository
    {
        Task<IEnumerable<VinculoInstitucional>> GetAllAsync();
        Task<VinculoInstitucional?> GetByIdAsync(Guid id);
        Task<IEnumerable<VinculoInstitucional>> SearchByNameAsync(string term);
        Task<VinculoInstitucional> AddAsync(VinculoInstitucional entity);
        Task<VinculoInstitucional> UpdateAsync(VinculoInstitucional entity);
        Task DeleteAsync(Guid id);
    }
}
