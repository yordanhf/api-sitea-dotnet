// Domain/Interfaces/ITipoInterconsultaRepository.cs
using ApiSitea.Domain.Entities;

namespace ApiSitea.Domain.Interfaces
{
    public interface ITipoInterconsultaRepository
    {
        Task<IEnumerable<TipoInterconsulta>> GetAllAsync();
        Task<TipoInterconsulta?> GetByIdAsync(Guid id);
        Task<IEnumerable<TipoInterconsulta>> SearchByNameAsync(string term);
        Task<TipoInterconsulta> AddAsync(TipoInterconsulta entity);
        Task<TipoInterconsulta> UpdateAsync(TipoInterconsulta entity);
        Task DeleteAsync(Guid id);
    }
}
