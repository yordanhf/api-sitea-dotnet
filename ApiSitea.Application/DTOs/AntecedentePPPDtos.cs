using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSitea.Application.DTOs
{
    public class AntecedentePPPDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
    public class AntecedentePPPCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
    public class AntecedentePPPUpdateDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
  
}
