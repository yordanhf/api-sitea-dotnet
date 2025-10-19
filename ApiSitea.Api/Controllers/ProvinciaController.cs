using ApiSitea.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiSitea.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinciasController : ControllerBase
    {
        private readonly IProvinciaService _provinciaService;

        public ProvinciasController(IProvinciaService provinciaService)
        {
            _provinciaService = provinciaService;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Obtiene todas las provincias",
            Description = "Retorna la lista de todas las provincias disponibles"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var provincias = await _provinciaService.GetAllAsync();
            return Ok(provincias);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obtiene una provincia por su ID",
            Description = "Retorna una provincia específica basada en su ID"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var provincia = await _provinciaService.GetByIdAsync(id);
            if (provincia == null)
                return NotFound($"No se encontró la provincia con ID: {id}");

            return Ok(provincia);
        }
        
      
    }
}