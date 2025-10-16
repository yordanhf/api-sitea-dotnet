// Domain/Interfaces/ITipoExamenRepository.cs
using ApiSitea.Domain.Entities;

namespace ApiSitea.Domain.Interfaces
{
    public interface ITipoExamenRepository
    {
        Task<IEnumerable<TipoExamen>> GetAllAsync();
        Task<TipoExamen?> GetByIdAsync(Guid id);
        Task<IEnumerable<TipoExamen>> SearchByNameAsync(string term);
        Task<TipoExamen> AddAsync(TipoExamen entity);
        Task<TipoExamen> UpdateAsync(TipoExamen entity);
        Task DeleteAsync(Guid id);
    }
}
