using ApiSitea.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSitea.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSitea.Domain.Entities;


namespace ApiSitea.Infrastructure.Repositories
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly AppDbContext _context;

        public MedicamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medicamento>> GetAllAsync()
        {
            return await _context.Medicamentos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Medicamento?> GetByIdAsync(Guid id)
        {
            return await _context.Medicamentos
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Medicamento> AddAsync(Medicamento medicamento)
        {
            _context.Medicamentos.Add(medicamento);
            await _context.SaveChangesAsync();
            return medicamento;
        }

        public async Task<Medicamento> UpdateAsync(Medicamento medicamento)
        {
            var exists = await _context.Medicamentos.AnyAsync(m => m.Id == medicamento.Id);
            if (!exists)
                throw new KeyNotFoundException($"No se encontró el medicamento con Id {medicamento.Id}");

            _context.Medicamentos.Update(medicamento);
            await _context.SaveChangesAsync();
            return medicamento;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Medicamentos.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"No se encontró el medicamento con Id {id}");

            _context.Medicamentos.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // 🔍 Nuevo método: búsqueda parcial por nombre
        public async Task<IEnumerable<Medicamento>> SearchByNameAsync(string searchTerm)
        {
            return await _context.Medicamentos
                .AsNoTracking()
                .Where(m => EF.Functions.Like(m.Nombre.ToLower(), $"%{searchTerm.ToLower()}%"))
                .ToListAsync();
        }
    }
}
