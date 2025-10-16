using ApiSitea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSitea.Domain.Interfaces
{
    public interface IAntecedentePPPRepository
    {
        Task<IEnumerable<AntecedentePPP>> GetAllAsync();
        Task<AntecedentePPP?> GetByIdAsync(Guid id);
        Task<AntecedentePPP> AddAsync(AntecedentePPP entity);
        Task<AntecedentePPP> UpdateAsync(AntecedentePPP entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<AntecedentePPP>> SearchByNameAsync(string searchTerm);
    }
}
