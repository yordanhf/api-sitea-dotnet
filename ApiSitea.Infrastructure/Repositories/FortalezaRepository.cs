// File: Infrastructure/Repositories/FortalezaRepository.cs
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using ApiSitea.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiSitea.Infrastructure.Repositories
{
    public class FortalezaRepository : IFortalezaRepository
    {
        private readonly AppDbContext _context;

        public FortalezaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fortaleza>> GetAllAsync()
        {
            return await _context.Fortalezas.AsNoTracking().ToListAsync();
        }

        public async Task<Fortaleza?> GetByIdAsync(Guid id)
        {
            return await _context.Fortalezas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Fortaleza>> SearchByNameAsync(string term)
        {
            return await _context.Fortalezas
                .Where(x => EF.Functions.Like(x.Nombre, $"%{term}%"))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Fortaleza> AddAsync(Fortaleza entity)
        {
            _context.Fortalezas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Fortaleza> UpdateAsync(Fortaleza entity)
        {
            var exists = await _context.Fortalezas.AnyAsync(x => x.Id == entity.Id);
            if (!exists)
                throw new KeyNotFoundException($"No se encontró la Fortaleza con Id {entity.Id}");

            _context.Fortalezas.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Fortalezas.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"No se encontró la Fortaleza con Id {id}");

            _context.Fortalezas.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
