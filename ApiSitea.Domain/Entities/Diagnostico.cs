using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSitea.Domain.Entities
{
    public class Diagnostico
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
    }
}