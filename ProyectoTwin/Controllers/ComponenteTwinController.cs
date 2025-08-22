using Microsoft.AspNetCore.Mvc;
using ProyectoTwin.Services;
using ProyectoTwin.DTOs;
using Microsoft.Extensions.Logging;


namespace ProyectoTwin.Controllers
{
    [ApiController]
    [Route("api/ComponenteTwin")]
    public class ComponenteTwinController : ControllerBase
    {
        private readonly IComponenteTwinService _service;
        private readonly ILogger<ComponenteTwinController> _logger;

        public ComponenteTwinController(IComponenteTwinService service, ILogger<ComponenteTwinController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene una lista paginada y filtrada de componentes twin.
        /// </summary>
        /// <param name="nombre">Filtrar por nombre (opcional)</param>
        /// <param name="estadoReal">Filtrar por estado real (opcional)</param>
        /// <param name="estadoDigital">Filtrar por estado digital (opcional)</param>
        /// <param name="numeroPagina">Número de página (por defecto 1)</param>
        /// <param name="tamanoPagina">Tamaño de página (por defecto 10)</param>
        /// <returns>Lista paginada y filtrada de componentes twin y el total de elementos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponenteTwinDto>>> GetPagedFiltered(
            [FromQuery] string? nombre = null,
            [FromQuery] string? estadoReal = null,
            [FromQuery] string? estadoDigital = null,
            [FromQuery] int numeroPagina = 1,
            [FromQuery] int tamanoPagina = 10)
        {
            _logger.LogInformation("Obteniendo componentes twin paginados y filtrados");
            try
            {
                var (items, total) = await _service.GetPagedFilteredAsync(nombre, estadoReal, estadoDigital, numeroPagina, tamanoPagina);
                return Ok(new { items, total });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los componentes twin paginados y filtrados");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComponenteTwinDto>> GetById(int id)
        {
            _logger.LogInformation("Obteniendo componente twin con id {Id}", id);
            try
            {
                var dto = await _service.GetByIdAsync(id);
                if (dto == null)
                {
                    _logger.LogWarning("No se encontró el componente twin con id {Id}", id);
                    return NotFound();
                }
                _logger.LogInformation("Componente twin con id {Id} encontrado", id);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el componente twin con id {Id}", id);
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
