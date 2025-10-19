using ApiSitea.Domain.Entities;

namespace ApiSitea.Application.Interfaces
{
    public interface IProvinciaService
    {
        Task<IEnumerable<Provincia>> GetAllAsync();
        Task<Provincia?> GetByIdAsync(int id);
        Task<bool> ExisteProvinciaAsync(int id);
    }
}