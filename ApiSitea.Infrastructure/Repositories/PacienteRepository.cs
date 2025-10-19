using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using ApiSitea.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiSitea.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _context;

        public PacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _context.Pacientes
                .Include(p => p.Municipio)
                .Include(p => p.Centro)
                .Include(p => p.Diagnostico)
                .Include(p => p.VinculoInstitucional)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Paciente?> GetByIdAsync(Guid id)
        {
            return await _context.Pacientes
                .Include(p => p.Municipio)
                .Include(p => p.Centro)
                .Include(p => p.Diagnostico)
                .Include(p => p.VinculoInstitucional)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Pacientes.FindAsync(id);
            if (entity != null)
            {
                _context.Pacientes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Búsqueda flexible tipo LIKE por nombre, apellidos y/o CI.
        /// Si un parámetro es null o vacío se ignora.
        /// Busqueda case-insensitive para nombre y apellidos (se usa ToLower()).
        /// CI se compara con LIKE sin lower (porque puede incluir números).
        /// </summary>
        public async Task<IEnumerable<Paciente>> SearchAsync(string? nombre, string? apellidos, string? ci)
        {
            var query = _context.Pacientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                var nombreLower = nombre.Trim().ToLower();
                query = query.Where(p => EF.Functions.Like(p.Nombre.ToLower(), $"%{nombreLower}%"));
            }

            if (!string.IsNullOrWhiteSpace(apellidos))
            {
                var apellidosLower = apellidos.Trim().ToLower();
                query = query.Where(p => EF.Functions.Like(p.Apellidos.ToLower(), $"%{apellidosLower}%"));
            }

            if (!string.IsNullOrWhiteSpace(ci))
            {
                var ciTrim = ci.Trim();
                query = query.Where(p => EF.Functions.Like(p.Ci, $"%{ciTrim}%"));
            }

            return await query
                .Include(p => p.Municipio)
                .Include(p => p.Centro)
                .Include(p => p.Diagnostico)
                .Include(p => p.VinculoInstitucional)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
