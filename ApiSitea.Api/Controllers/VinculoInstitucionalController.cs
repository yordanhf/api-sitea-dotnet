// Api/Controllers/VinculoInstitucionalController.cs
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiSitea.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VinculoInstitucionalController : ControllerBase
    {
        private readonly IVinculoInstitucionalService _service;

        public VinculoInstitucionalController(IVinculoInstitucionalService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> Search([FromQuery] string term) =>
            Ok(await _service.SearchByNameAsync(term));

        [HttpPost]
        public async Task<IActionResult> Create(VinculoInstitucionalCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, VinculoInstitucionalUpdateDto dto) =>
            Ok(await _service.UpdateAsync(id, dto));

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
