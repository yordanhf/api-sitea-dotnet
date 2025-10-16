using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiSitea.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FortalezaController : ControllerBase
    {
        private readonly IFortalezaService _service;
        private readonly ILogger<FortalezaController> _logger;

        public FortalezaController(IFortalezaService service, ILogger<FortalezaController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // ==================================================
        // GET: api/fortaleza
        // ==================================================
        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene todas las fortalezas")]
        [ProducesResponseType(typeof(IEnumerable<FortalezaDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Solicitando todas las fortalezas");
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        // ==================================================
        // GET: api/fortaleza/{id}
        // ==================================================
        [HttpGet("{id:guid}")]
        [SwaggerOperation(Summary = "Obtiene una fortaleza por su Id")]
        [ProducesResponseType(typeof(FortalezaDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
            {
                _logger.LogWarning("Fortaleza no encontrada: {FortalezaId}", id);
                return NotFound(new { Message = "Fortaleza no encontrada" });
            }

            return Ok(item);
        }

        // ==================================================
        // GET: api/fortaleza/search?term=texto
        // ==================================================
        [HttpGet("search")]
        [SwaggerOperation(Summary = "Busca fortalezas por nombre (búsqueda parcial con LIKE)")]
        [ProducesResponseType(typeof(IEnumerable<FortalezaDto>), 200)]
        public async Task<IActionResult> SearchByName([FromQuery] string term)
        {
            _logger.LogInformation("Buscando fortalezas que contengan el término: {Term}", term);
            var results = await _service.SearchByNameAsync(term);
            return Ok(results);
        }

        // ==================================================
        // POST: api/fortaleza
        // ==================================================
        [HttpPost]
        [SwaggerOperation(Summary = "Crea una nueva fortaleza")]
        [ProducesResponseType(typeof(FortalezaDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] FortalezaCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            _logger.LogInformation("Fortaleza creada correctamente con Id {FortalezaId}", created.Id);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // ==================================================
        // PUT: api/fortaleza/{id}
        // ==================================================
        [HttpPut("{id:guid}")]
        [SwaggerOperation(Summary = "Actualiza una fortaleza existente")]
        [ProducesResponseType(typeof(FortalezaDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(Guid id, [FromBody] FortalezaUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            _logger.LogInformation("Fortaleza actualizada correctamente con Id {FortalezaId}", id);
            return Ok(updated);
        }

        // ==================================================
        // DELETE: api/fortaleza/{id}
        // ==================================================
        [HttpDelete("{id:guid}")]
        [SwaggerOperation(Summary = "Elimina una fortaleza por su Id")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            _logger.LogInformation("Fortaleza eliminada con Id {FortalezaId}", id);
            return NoContent();
        }
    }
}
