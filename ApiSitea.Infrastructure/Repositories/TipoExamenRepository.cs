// File: Infrastructure/Repositories/TipoExamenRepository.cs
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using ApiSitea.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiSitea.Infrastructure.Repositories
{
    public class TipoExamenRepository : ITipoExamenRepository
    {
        private readonly AppDbContext _context;

        public TipoExamenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoExamen>> GetAllAsync()
        {
            return await _context.TiposExamen.AsNoTracking().ToListAsync();
        }

        public async Task<TipoExamen?> GetByIdAsync(Guid id)
        {
            return await _context.TiposExamen.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TipoExamen>> SearchByNameAsync(string term)
        {
            return await _context.TiposExamen
                .Where(x => EF.Functions.Like(x.Nombre, $"%{term}%"))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TipoExamen> AddAsync(TipoExamen entity)
        {
            _context.TiposExamen.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TipoExamen> UpdateAsync(TipoExamen entity)
        {
            var exists = await _context.TiposExamen.AnyAsync(x => x.Id == entity.Id);
            if (!exists)
                throw new KeyNotFoundException($"No se encontró la TipoExamen con Id {entity.Id}");

            _context.TiposExamen.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.TiposExamen.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"No se encontró la TipoExamen con Id {id}");

            _context.TiposExamen.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
