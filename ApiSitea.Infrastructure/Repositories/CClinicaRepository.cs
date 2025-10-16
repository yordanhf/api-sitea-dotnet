// File: Infrastructure/Repositories/CClinicaRepository.cs
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using ApiSitea.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiSitea.Infrastructure.Repositories
{
    public class CClinicaRepository : ICClinicaRepository
    {
        private readonly AppDbContext _context;

        public CClinicaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CClinica>> GetAllAsync()
        {
            return await _context.CClinicas.AsNoTracking().ToListAsync();
        }

        public async Task<CClinica?> GetByIdAsync(Guid id)
        {
            return await _context.CClinicas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<CClinica>> SearchByNameAsync(string term)
        {
            return await _context.CClinicas
                .Where(x => EF.Functions.Like(x.Nombre, $"%{term}%"))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CClinica> AddAsync(CClinica entity)
        {
            _context.CClinicas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CClinica> UpdateAsync(CClinica entity)
        {
            var exists = await _context.CClinicas.AnyAsync(x => x.Id == entity.Id);
            if (!exists)
                throw new KeyNotFoundException($"No se encontró la característica clínica con Id {entity.Id}");

            _context.CClinicas.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.CClinicas.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"No se encontró la característica clínica con Id {id}");

            _context.CClinicas.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
