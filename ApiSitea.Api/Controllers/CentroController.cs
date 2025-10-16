using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiSitea.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CentroController : ControllerBase
    {
        private readonly ICentroService _service;
        private readonly ILogger<CentroController> _logger;

        public CentroController(ICentroService service, ILogger<CentroController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene todos los centros")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:guid}")]
        [SwaggerOperation(Summary = "Obtiene un centro por su Id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpGet("buscar/{nombre}")]
        [SwaggerOperation(Summary = "Busca centros por nombre (LIKE)")]
        public async Task<IActionResult> SearchByName(string nombre)
        {
            var results = await _service.SearchByNameAsync(nombre);
            return Ok(results);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Crea un nuevo centro")]
        public async Task<IActionResult> Create(CentroCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        [SwaggerOperation(Summary = "Actualiza un centro existente")]
        public async Task<IActionResult> Update(Guid id, CentroUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        [SwaggerOperation(Summary = "Elimina un centro")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}