using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSitea.Application.DTOs
{
    public class VinculoInstitucionalDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
    public class VinculoInstitucionalCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
    public class VinculoInstitucionalUpdateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
}

