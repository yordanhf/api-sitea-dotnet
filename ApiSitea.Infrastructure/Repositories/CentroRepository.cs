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
    public class CentroRepository : ICentroRepository
    {
        private readonly AppDbContext _context;

        public CentroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Centro>> GetAllAsync()
        {
            return await _context.Centros
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Centro?> GetByIdAsync(Guid id)
        {
            return await _context.Centros
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Centro> AddAsync(Centro centro)
        {
            _context.Centros.Add(centro);
            await _context.SaveChangesAsync();
            return centro;
        }

        public async Task<Centro> UpdateAsync(Centro centro)
        {
            var exists = await _context.Centros.AnyAsync(c => c.Id == centro.Id);
            if (!exists)
                throw new KeyNotFoundException($"No se encontró el centro con Id {centro.Id}");

            _context.Centros.Update(centro);
            await _context.SaveChangesAsync();
            return centro;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Centros.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"No se encontró el centro con Id {id}");

            _context.Centros.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Centro>> SearchByNameAsync(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return new List<Centro>();

            return await _context.Centros
                .Where(c => EF.Functions.Like(c.Nombre.ToLower(), $"%{nombre.ToLower()}%"))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}