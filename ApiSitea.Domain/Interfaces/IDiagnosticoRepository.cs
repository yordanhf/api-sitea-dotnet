// Domain/Interfaces/IDiagnosticoRepository.cs
using ApiSitea.Domain.Entities;

namespace ApiSitea.Domain.Interfaces
{
    public interface IDiagnosticoRepository
    {
        Task<IEnumerable<Diagnostico>> GetAllAsync();
        Task<Diagnostico?> GetByIdAsync(Guid id);
        Task<IEnumerable<Diagnostico>> SearchByNameAsync(string term);
        Task<Diagnostico> AddAsync(Diagnostico entity);
        Task<Diagnostico> UpdateAsync(Diagnostico entity);
        Task DeleteAsync(Guid id);
    }
}
