using ApiSitea.Domain.Entities;

namespace ApiSitea.Domain.Interfaces
{
    public interface IProvinciaRepository
    {
        Task<IEnumerable<Provincia>> GetAllAsync();
        Task<Provincia?> GetByIdAsync(int id);
        Task<bool> ExisteProvinciaAsync(int id);
    }
}