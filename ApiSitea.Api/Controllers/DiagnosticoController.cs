using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiSitea.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoService _service;
        private readonly ILogger<DiagnosticoController> _logger;

        public DiagnosticoController(IDiagnosticoService service, ILogger<DiagnosticoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los diagnósticos.
        /// </summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene todos los diagnósticos")]
        [ProducesResponseType(typeof(IEnumerable<DiagnosticoDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Solicitando todos los diagnósticos");
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        /// <summary>
        /// Obtiene un diagnóstico por su Id.
        /// </summary>
        [HttpGet("{id:guid}")]
        [SwaggerOperation(Summary = "Obtiene un diagnóstico por Id")]
        [ProducesResponseType(typeof(DiagnosticoDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Solicitando diagnóstico con Id {Id}", id);
            var item = await _service.GetByIdAsync(id);
            if (item == null)
            {
                _logger.LogWarning("Diagnóstico con Id {Id} no encontrado", id);
                return NotFound();
            }

            return Ok(item);
        }

        /// <summary>
        /// Busca diagnósticos por nombre (coincidencia parcial).
        /// </summary>
        [HttpGet("buscar")]
        [SwaggerOperation(Summary = "Busca diagnósticos por nombre (LIKE)")]
        [ProducesResponseType(typeof(IEnumerable<DiagnosticoDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            _logger.LogInformation("Búsqueda de diagnósticos por término: {Term}", term);

            if (string.IsNullOrWhiteSpace(term))
            {
                _logger.LogWarning("Término de búsqueda vacío");
                return BadRequest(new { Message = "Debe proporcionar un término de búsqueda." });
            }

            var results = await _service.SearchByNameAsync(term);
            return Ok(results);
        }

        /// <summary>
        /// Crea un nuevo diagnóstico.
        /// </summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Crea un nuevo diagnóstico")]
        [ProducesResponseType(typeof(DiagnosticoDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] DiagnosticoCreateDto dto)
        {
            _logger.LogInformation("Creando diagnóstico con nombre: {Nombre}", dto?.Nombre);
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Actualiza un diagnóstico existente.
        /// </summary>
        [HttpPut("{id:guid}")]
        [SwaggerOperation(Summary = "Actualiza un diagnóstico")]
        [ProducesResponseType(typeof(DiagnosticoDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(Guid id, [FromBody] DiagnosticoUpdateDto dto)
        {
            _logger.LogInformation("Actualizando diagnóstico {Id}", id);

            // Service lanzará KeyNotFoundException si no existe; ExceptionMiddleware lo maneja.
            var updated = await _service.UpdateAsync(id, dto);
            return Ok(updated);
        }

        /// <summary>
        /// Elimina un diagnóstico.
        /// </summary>
        [HttpDelete("{id:guid}")]
        [SwaggerOperation(Summary = "Elimina un diagnóstico")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Eliminando diagnóstico {Id}", id);
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
