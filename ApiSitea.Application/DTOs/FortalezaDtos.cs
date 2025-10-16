// File: Application/DTOs/CClinicaDtos.cs
namespace ApiSitea.Application.DTOs
{
    public class FortalezaDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class FortalezaCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }

    public class FortalezaUpdateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
}
