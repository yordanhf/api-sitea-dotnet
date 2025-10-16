// File: Application/DTOs/CClinicaDtos.cs
namespace ApiSitea.Application.DTOs
{
    public class CClinicaDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class CClinicaCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }

    public class CClinicaUpdateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
}
