// File: Domain/Interfaces/IComorbilidadRepository.cs
using ApiSitea.Domain.Entities;

namespace ApiSitea.Domain.Interfaces
{
    public interface IComorbilidadRepository
    {
        Task<IEnumerable<Comorbilidad>> GetAllAsync();
        Task<Comorbilidad?> GetByIdAsync(Guid id);
        Task<IEnumerable<Comorbilidad>> SearchByNameAsync(string term);
        Task<Comorbilidad> AddAsync(Comorbilidad entity);
        Task<Comorbilidad> UpdateAsync(Comorbilidad entity);
        Task DeleteAsync(Guid id);
    }
}
