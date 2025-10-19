using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiSitea.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Obtiene todos los pacientes",
            Description = "Retorna una lista de todos los pacientes registrados"
        )]
        [ProducesResponseType(typeof(IEnumerable<PacienteDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PacienteDto>>> GetAll()
        {
            var pacientes = await _pacienteService.GetAllAsync();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obtiene un paciente por ID",
            Description = "Retorna un paciente específico basado en su ID"
        )]
        [ProducesResponseType(typeof(PacienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PacienteDto>> GetById(Guid id)
        {
            var paciente = await _pacienteService.GetByIdAsync(id);
            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Crea un nuevo paciente",
            Description = "Crea un nuevo paciente con los datos proporcionados"
        )]
        [ProducesResponseType(typeof(PacienteDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PacienteDto>> Create(PacienteCreateDto pacienteDto)
        {
            var paciente = await _pacienteService.CreateAsync(pacienteDto);
            return CreatedAtAction(nameof(GetById), new { id = paciente.Id }, paciente);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Actualiza un paciente existente",
            Description = "Actualiza los datos de un paciente existente basado en su ID"
        )]
        [ProducesResponseType(typeof(PacienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PacienteDto>> Update(int id, PacienteUpdateDto pacienteDto)
        {
            if (id != pacienteDto.Id)
                return BadRequest();

            try
            {
                var paciente = await _pacienteService.UpdateAsync(pacienteDto);
                return Ok(paciente);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Elimina un paciente",
            Description = "Elimina un paciente existente basado en su ID"
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _pacienteService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        [SwaggerOperation(
            Summary = "Busca pacientes",
            Description = "Busca pacientes por nombre, apellidos y/o CI"
        )]
        [ProducesResponseType(typeof(IEnumerable<PacienteDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PacienteDto>>> Search(
            [FromQuery] string? nombre,
            [FromQuery] string? apellidos,
            [FromQuery] string? ci)
        {
            var pacientes = await _pacienteService.SearchAsync(nombre, apellidos, ci);
            return Ok(pacientes);
        }
    }
}