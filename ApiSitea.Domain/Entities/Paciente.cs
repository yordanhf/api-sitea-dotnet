

namespace ApiSitea.Domain.Entities
{
    public class Paciente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Ci { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string Raza { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string MotivoConsulta { get; set; } = string.Empty;
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? AntecedentesPF { get; set; }
        public string? Observaciones { get; set; }

        public bool Verbal { get; set; }
        public int? EdadDiagnostico { get; set; }
        public DateOnly? FechaDiagnostico { get; set; }
        public bool Terapia { get; set; }
        public string? DescripcionTerapia { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; } = default!;
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; } = default!;

        public Guid CentroId { get; set; }
        public Centro Centro { get; set; } = default!;

        public Guid DiagnosticoId { get; set; }
        public Diagnostico Diagnostico { get; set; } = default!;

        public Guid VinculoInstitucionalId { get; set; }
        public VinculoInstitucional VinculoInstitucional { get; set; } = default!;
    }
}
