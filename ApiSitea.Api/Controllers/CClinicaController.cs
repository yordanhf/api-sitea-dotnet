// File: Api/Controllers/CClinicaController.cs
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiSitea.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CClinicaController : ControllerBase
    {
        private readonly ICClinicaService _service;
        private readonly ILogger<CClinicaController> _logger;

        public CClinicaController(ICClinicaService service, ILogger<CClinicaController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene todas las características clínicas")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:guid}")]
        [SwaggerOperation(Summary = "Obtiene una característica clínica por Id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpGet("buscar")]
        [SwaggerOperation(Summary = "Busca características clínicas por nombre (LIKE)")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            var items = await _service.SearchByNameAsync(term);
            return Ok(items);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Crea una nueva característica clínica")]
        public async Task<IActionResult> Create(CClinicaCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        [SwaggerOperation(Summary = "Actualiza una característica clínica")]
        public async Task<IActionResult> Update(Guid id, CClinicaUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        [SwaggerOperation(Summary = "Elimina una característica clínica")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
