// File: Api/Controllers/ComorbilidadController.cs
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiSitea.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComorbilidadController : ControllerBase
    {
        private readonly IComorbilidadService _service;
        private readonly ILogger<ComorbilidadController> _logger;

        public ComorbilidadController(IComorbilidadService service, ILogger<ComorbilidadController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene todas las comorbilidades")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:guid}")]
        [SwaggerOperation(Summary = "Obtiene una comorbilidad por Id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpGet("buscar")]
        [SwaggerOperation(Summary = "Busca comorbilidades por nombre (LIKE)")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            var items = await _service.SearchByNameAsync(term);
            return Ok(items);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Crea una nueva comorbilidad")]
        public async Task<IActionResult> Create(ComorbilidadCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        [SwaggerOperation(Summary = "Actualiza una comorbilidad")]
        public async Task<IActionResult> Update(Guid id, ComorbilidadUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        [SwaggerOperation(Summary = "Elimina una comorbilidad")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
