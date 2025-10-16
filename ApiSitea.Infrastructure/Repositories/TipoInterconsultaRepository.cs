// Infrastructure/Repositories/TipoInterconsultaRepository.cs
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using ApiSitea.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiSitea.Infrastructure.Repositories
{
    public class TipoInterconsultaRepository : ITipoInterconsultaRepository
    {
        private readonly AppDbContext _context;
        public TipoInterconsultaRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<TipoInterconsulta>> GetAllAsync() =>
            await _context.TiposInterconsulta.AsNoTracking().ToListAsync();

        public async Task<TipoInterconsulta?> GetByIdAsync(Guid id) =>
            await _context.TiposInterconsulta.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<TipoInterconsulta>> SearchByNameAsync(string term) =>
            await _context.TiposInterconsulta
                .Where(x => EF.Functions.Like(x.Nombre, $"%{term}%"))
                .AsNoTracking()
                .ToListAsync();

        public async Task<TipoInterconsulta> AddAsync(TipoInterconsulta entity)
        {
            _context.TiposInterconsulta.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TipoInterconsulta> UpdateAsync(TipoInterconsulta entity)
        {
            var exists = await _context.TiposInterconsulta.AnyAsync(x => x.Id == entity.Id);
            if (!exists) throw new KeyNotFoundException($"No se encontró el diagnóstico con Id {entity.Id}");

            _context.TiposInterconsulta.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.TiposInterconsulta.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException($"No se encontró el diagnóstico con Id {id}");

            _context.TiposInterconsulta.Remove(entity);
            await _context.SaveChangesAsync();
        }

       
    }
}
