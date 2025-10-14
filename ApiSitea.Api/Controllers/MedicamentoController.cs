using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;

namespace ApiSitea.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoService _service;
        private readonly ILogger<MedicamentoController> _logger;

        public MedicamentoController(IMedicamentoService service, ILogger<MedicamentoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene todos los medicamentos")]
        [ProducesResponseType(typeof(IEnumerable<MedicamentoDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Solicitando todos los medicamentos");
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:guid}")]
        [SwaggerOperation(Summary = "Obtiene un medicamento por id")]
        [ProducesResponseType(typeof(MedicamentoDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Crea un medicamento")]
        [ProducesResponseType(typeof(MedicamentoDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create(MedicamentoCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        [SwaggerOperation(Summary = "Actualiza un medicamento")]
        [ProducesResponseType(typeof(MedicamentoDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(Guid id, MedicamentoUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        [SwaggerOperation(Summary = "Elimina un medicamento")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
