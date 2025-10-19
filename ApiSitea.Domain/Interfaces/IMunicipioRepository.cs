using ApiSitea.Domain.Entities;

namespace ApiSitea.Domain.Interfaces
{
    public interface IMunicipioRepository
    {
        Task<IEnumerable<Municipio>> GetByProvinciaIdAsync(int provinciaId);
        Task<Municipio?> GetByIdAsync(int provinciaId, int municipioId);
        Task<bool> ExisteMunicipioEnProvinciaAsync(int provinciaId, int municipioId);
    }
}