using ApiSitea.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiSitea.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipiosController : ControllerBase
    {
        private readonly IMunicipioService _municipioService;

        public MunicipiosController(IMunicipioService municipioService)
        {
            _municipioService = municipioService;
        }

        [HttpGet("provincia/{provinciaId}")]
        [SwaggerOperation(
            Summary = "Obtiene los municipios de una provincia",
            Description = "Retorna la lista de municipios que pertenecen a una provincia específica"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByProvinciaId(int provinciaId)
        {
            var municipios = await _municipioService.GetByProvinciaIdAsync(provinciaId);
            if (!municipios.Any())
                return NotFound($"No se encontraron municipios para la provincia con ID: {provinciaId}");

            return Ok(municipios);
        }

        [HttpGet("provincia/{provinciaId}/municipio/{municipioId}")]
        [SwaggerOperation(
            Summary = "Obtiene un municipio específico de una provincia",
            Description = "Retorna un municipio específico basado en su ID y el ID de su provincia"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int provinciaId, int municipioId)
        {
            var municipio = await _municipioService.GetByIdAsync(provinciaId, municipioId);
            if (municipio == null)
                return NotFound($"No se encontró el municipio con ID: {municipioId} en la provincia con ID: {provinciaId}");

            return Ok(municipio);
        }
    }
}