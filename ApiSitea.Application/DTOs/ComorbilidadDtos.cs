// File: Application/DTOs/ComorbilidadDtos.cs
namespace ApiSitea.Application.DTOs
{
    public class ComorbilidadDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class ComorbilidadCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }

    public class ComorbilidadUpdateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
}
