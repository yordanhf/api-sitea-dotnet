// Domain/Interfaces/IFortalezaRepository.cs
using ApiSitea.Domain.Entities;

namespace ApiSitea.Domain.Interfaces
{
    public interface IFortalezaRepository
    {
        Task<IEnumerable<Fortaleza>> GetAllAsync();
        Task<Fortaleza?> GetByIdAsync(Guid id);
        Task<IEnumerable<Fortaleza>> SearchByNameAsync(string term);
        Task<Fortaleza> AddAsync(Fortaleza entity);
        Task<Fortaleza> UpdateAsync(Fortaleza entity);
        Task DeleteAsync(Guid id);
    }
}
