namespace ApiSitea.Application.DTOs
{
    public class PacienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Ci { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public string? Raza { get; set; }
        public string? Direccion { get; set; }
        public string? MotivoConsulta { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? DescripcionTerapia { get; set; }
        public int ProvinciaId { get; set; }
        public string ProvinciaNombre { get; set; } = string.Empty;
        public int MunicipioId { get; set; }
        public string MunicipioNombre { get; set; } = string.Empty;
        public int CentroId { get; set; }
        public int DiagnosticoId { get; set; }
        public int VinculoInstitucionalId { get; set; }

        // Navegación opcional (solo lectura)       
        public string? CentroNombre { get; set; }
        public string? DiagnosticoNombre { get; set; }
        public string? VinculoInstitucionalNombre { get; set; }
    }

    public class PacienteCreateDto
    {
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Ci { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public string? Raza { get; set; }
        public string? Direccion { get; set; }
        public string? MotivoConsulta { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? DescripcionTerapia { get; set; }
        public int ProvinciaId { get; set; }       
        public int MunicipioId { get; set; }      
        public int CentroId { get; set; }
        public int DiagnosticoId { get; set; }
        public int VinculoInstitucionalId { get; set; }
    }

    public class PacienteUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Ci { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public string? Raza { get; set; }
        public string? Direccion { get; set; }
        public string? MotivoConsulta { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? DescripcionTerapia { get; set; }
        public int ProvinciaId { get; set; }        
        public int MunicipioId { get; set; }        
        public int CentroId { get; set; }
        public int DiagnosticoId { get; set; }
        public int VinculoInstitucionalId { get; set; }
    }
}
