// Application/DTOs/DiagnosticoDtos.cs
namespace ApiSitea.Application.DTOs
{
    public class DiagnosticoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class DiagnosticoCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }

    public class DiagnosticoUpdateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
}
