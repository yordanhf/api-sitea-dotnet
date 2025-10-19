using ApiSitea.Domain.Entities;

namespace ApiSitea.Application.Interfaces
{
    public interface IMunicipioService
    {
        Task<IEnumerable<Municipio>> GetByProvinciaIdAsync(int provinciaId);
        Task<Municipio?> GetByIdAsync(int provinciaId, int municipioId);
        Task<bool> ExisteMunicipioEnProvinciaAsync(int provinciaId, int municipioId);
    }
}