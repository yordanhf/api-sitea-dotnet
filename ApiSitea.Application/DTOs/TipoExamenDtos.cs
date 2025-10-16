using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSitea.Application.DTOs
{
    public class TipoExamenDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
    public class TipoExamenCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
    public class TipoExamenUpdateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
}

