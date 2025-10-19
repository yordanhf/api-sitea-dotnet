using ApiSitea.Domain.Entities;

namespace ApiSitea.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<Paciente?> GetByIdAsync(Guid id);
        Task AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task DeleteAsync(Guid id);

        // Búsqueda tipo LIKE por nombre, apellidos o CI (cada parámetro es opcional)
        Task<IEnumerable<Paciente>> SearchAsync(string? nombre, string? apellidos, string? ci);
    }
}
