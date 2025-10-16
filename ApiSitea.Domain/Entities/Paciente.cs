using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSitea.Domain.Entities
{
    public class Paciente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string Raza { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string MotivoConsulta { get; set; } = string.Empty;
        public string AntecedentesPF { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;

        public Boolean Verbal { get; set; }
        public int EdadDiagnostico { get; set; }
        public DateOnly FechaDiagnostico {  get; set; }
        public Boolean Terapia { get; set; }
        public string DescripcionTerapia { get; set; } = string.Empty;


    }
}


