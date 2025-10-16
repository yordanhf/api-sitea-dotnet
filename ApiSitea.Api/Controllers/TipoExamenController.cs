// Api/Controllers/TipoExamenController.cs
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiSitea.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoExamenController : ControllerBase
    {
        private readonly ITipoExamenService _service;

        public TipoExamenController(ITipoExamenService service) => _service = service;

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
        public async Task<IActionResult> Create(TipoExamenCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, TipoExamenUpdateDto dto) =>
            Ok(await _service.UpdateAsync(id, dto));

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
