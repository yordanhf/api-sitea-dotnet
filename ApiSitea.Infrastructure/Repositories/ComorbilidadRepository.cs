// File: Infrastructure/Repositories/ComorbilidadRepository.cs
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using ApiSitea.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiSitea.Infrastructure.Repositories
{
    public class ComorbilidadRepository : IComorbilidadRepository
    {
        private readonly AppDbContext _context;

        public ComorbilidadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comorbilidad>> GetAllAsync()
        {
            return await _context.Comorbilidades.AsNoTracking().ToListAsync();
        }

        public async Task<Comorbilidad?> GetByIdAsync(Guid id)
        {
            return await _context.Comorbilidades.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Comorbilidad>> SearchByNameAsync(string term)
        {
            return await _context.Comorbilidades
                .Where(x => EF.Functions.Like(x.Nombre, $"%{term}%"))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Comorbilidad> AddAsync(Comorbilidad entity)
        {
            _context.Comorbilidades.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Comorbilidad> UpdateAsync(Comorbilidad entity)
        {
            var exists = await _context.Comorbilidades.AnyAsync(x => x.Id == entity.Id);
            if (!exists)
                throw new KeyNotFoundException($"No se encontró la comorbilidad con Id {entity.Id}");

            _context.Comorbilidades.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Comorbilidades.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"No se encontró la comorbilidad con Id {id}");

            _context.Comorbilidades.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
