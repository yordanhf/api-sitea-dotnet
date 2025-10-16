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
    public class AntecedentePPPRepository : IAntecedentePPPRepository
    {
        private readonly AppDbContext _context;

        public AntecedentePPPRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AntecedentePPP>> GetAllAsync()
        {
            return await _context.AntecedentesPPP
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AntecedentePPP?> GetByIdAsync(Guid id)
        {
            return await _context.AntecedentesPPP
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<AntecedentePPP> AddAsync(AntecedentePPP antecedente)
        {
            _context.AntecedentesPPP.Add(antecedente);
            await _context.SaveChangesAsync();
            return antecedente;
        }

        public async Task<AntecedentePPP> UpdateAsync(AntecedentePPP antecedente)
        {
            var exists = await _context.AntecedentesPPP.AnyAsync(a => a.Id == antecedente.Id);
            if (!exists)
                throw new KeyNotFoundException($"No se encontró el antecedente con Id {antecedente.Id}");

            _context.AntecedentesPPP.Update(antecedente);
            await _context.SaveChangesAsync();
            return antecedente;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.AntecedentesPPP.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"No se encontró el antecedente con Id {id}");

            _context.AntecedentesPPP.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // 🔍 Búsqueda parcial por nombre
        public async Task<IEnumerable<AntecedentePPP>> SearchByNameAsync(string searchTerm)
        {
            return await _context.AntecedentesPPP
                .AsNoTracking()
                .Where(a => EF.Functions.Like(a.Nombre.ToLower(), $"%{searchTerm.ToLower()}%"))
                .ToListAsync();
        }
    }
}
