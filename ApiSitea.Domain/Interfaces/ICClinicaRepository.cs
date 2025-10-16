// File: Domain/Interfaces/ICClinicaRepository.cs
using ApiSitea.Domain.Entities;

namespace ApiSitea.Domain.Interfaces
{
    public interface ICClinicaRepository
    {
        Task<IEnumerable<CClinica>> GetAllAsync();
        Task<CClinica?> GetByIdAsync(Guid id);
        Task<IEnumerable<CClinica>> SearchByNameAsync(string term);
        Task<CClinica> AddAsync(CClinica entity);
        Task<CClinica> UpdateAsync(CClinica entity);
        Task DeleteAsync(Guid id);
    }
}
