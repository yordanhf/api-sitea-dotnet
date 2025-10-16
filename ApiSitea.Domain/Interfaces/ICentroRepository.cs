using ApiSitea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSitea.Domain.Interfaces
{
    public interface ICentroRepository
    {
        Task<IEnumerable<Centro>> GetAllAsync();
        Task<Centro?> GetByIdAsync(Guid id);
        Task<Centro> AddAsync(Centro centro);
        Task<Centro> UpdateAsync(Centro centro);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Centro>> SearchByNameAsync(string nombre);
    }
}