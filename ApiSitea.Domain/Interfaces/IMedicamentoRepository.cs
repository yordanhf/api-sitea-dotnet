using ApiSitea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApiSitea.Domain.Interfaces
{
    public interface IMedicamentoRepository
    {
        Task<IEnumerable<Medicamento>> GetAllAsync();
        Task<Medicamento?> GetByIdAsync(Guid id);
        Task<Medicamento> AddAsync(Medicamento medicamento);
        Task<Medicamento> UpdateAsync(Medicamento medicamento);
        Task DeleteAsync(Guid id);

        Task<IEnumerable<Medicamento>> SearchByNameAsync(string searchTerm);
    }
}
