// File: Infrastructure/Repositories/VinculoInstitucionalRepository.cs
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using ApiSitea.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiSitea.Infrastructure.Repositories
{
    public class VinculoInstitucionalRepository : IVinculoInstitucionalRepository
    {
        private readonly AppDbContext _context;

        public VinculoInstitucionalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VinculoInstitucional>> GetAllAsync()
        {
            return await _context.VinculosInstitucionales.AsNoTracking().ToListAsync();
        }

        public async Task<VinculoInstitucional?> GetByIdAsync(Guid id)
        {
            return await _context.VinculosInstitucionales.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<VinculoInstitucional>> SearchByNameAsync(string term)
        {
            return await _context.VinculosInstitucionales
                .Where(x => EF.Functions.Like(x.Nombre, $"%{term}%"))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<VinculoInstitucional> AddAsync(VinculoInstitucional entity)
        {
            _context.VinculosInstitucionales.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<VinculoInstitucional> UpdateAsync(VinculoInstitucional entity)
        {
            var exists = await _context.VinculosInstitucionales.AnyAsync(x => x.Id == entity.Id);
            if (!exists)
                throw new KeyNotFoundException($"No se encontró la VinculoInstitucional con Id {entity.Id}");

            _context.VinculosInstitucionales.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.VinculosInstitucionales.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"No se encontró la VinculoInstitucional con Id {id}");

            _context.VinculosInstitucionales.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
