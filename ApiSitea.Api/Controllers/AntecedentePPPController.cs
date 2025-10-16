using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiSitea.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AntecedentePPPController : ControllerBase
    {
        private readonly IAntecedentePPPService _service;
        private readonly ILogger<AntecedentePPPController> _logger;

        public AntecedentePPPController(IAntecedentePPPService service, ILogger<AntecedentePPPController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene todos los antecedentes PPP")]
        [ProducesResponseType(typeof(IEnumerable<AntecedentePPPDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:guid}")]
        [SwaggerOperation(Summary = "Obtiene un antecedente PPP por id")]
        [ProducesResponseType(typeof(AntecedentePPPDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Crea un antecedente PPP")]
        [ProducesResponseType(typeof(AntecedentePPPDto), 201)]
        public async Task<IActionResult> Create(AntecedentePPPCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        [SwaggerOperation(Summary = "Actualiza un antecedente PPP")]
        [ProducesResponseType(typeof(AntecedentePPPDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(Guid id, AntecedentePPPDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        [SwaggerOperation(Summary = "Elimina un antecedente PPP")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        // 🔍 Nuevo método de búsqueda
        [HttpGet("buscar")]
        [SwaggerOperation(Summary = "Busca antecedentes PPP por nombre parcial")]
        [ProducesResponseType(typeof(IEnumerable<AntecedentePPPDto>), 200)]
        public async Task<IActionResult> SearchByName([FromQuery] string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return BadRequest(new { Message = "Debe proporcionar un término de búsqueda." });

            var items = await _service.SearchByNameAsync(nombre);
            return Ok(items);
        }
    }
}
