// Infrastructure/Repositories/DiagnosticoRepository.cs
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using ApiSitea.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiSitea.Infrastructure.Repositories
{
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        private readonly AppDbContext _context;
        public DiagnosticoRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Diagnostico>> GetAllAsync() =>
            await _context.Diagnosticos.AsNoTracking().ToListAsync();

        public async Task<Diagnostico?> GetByIdAsync(Guid id) =>
            await _context.Diagnosticos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Diagnostico>> SearchByNameAsync(string term) =>
            await _context.Diagnosticos
                .Where(x => EF.Functions.Like(x.Nombre, $"%{term}%"))
                .AsNoTracking()
                .ToListAsync();

        public async Task<Diagnostico> AddAsync(Diagnostico entity)
        {
            _context.Diagnosticos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Diagnostico> UpdateAsync(Diagnostico entity)
        {
            var exists = await _context.Diagnosticos.AnyAsync(x => x.Id == entity.Id);
            if (!exists) throw new KeyNotFoundException($"No se encontró el diagnóstico con Id {entity.Id}");

            _context.Diagnosticos.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Diagnosticos.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException($"No se encontró el diagnóstico con Id {id}");

            _context.Diagnosticos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
