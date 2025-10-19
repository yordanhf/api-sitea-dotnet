using ApiSitea.Application.DTOs;

namespace ApiSitea.Application.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDto>> GetAllAsync();
        Task<PacienteDto?> GetByIdAsync(Guid id);
        Task<PacienteDto> CreateAsync(PacienteCreateDto pacienteDto);
        Task<PacienteDto> UpdateAsync(PacienteUpdateDto pacienteDto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<PacienteDto>> SearchAsync(string? nombre, string? apellidos, string? ci);
    }
}